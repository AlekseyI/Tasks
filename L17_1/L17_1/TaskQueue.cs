using System;
using System.Collections.Concurrent;
using System.Threading;

namespace L17_1
{
    public class TaskQueue : IJobExecutor, IDisposable
    {
        private BlockingCollection<Action> _tasks;
        private AutoResetEvent _eventWaitTask;
        private Thread[] _workers;
        private CancellationTokenSource _sourceToken;
        private bool _isStart;
        private int _timeOut;
        
        public int Amount
        {
            get
            {
                return _tasks.Count;
            }
        }

        public TaskQueue()
        {
            _tasks = new BlockingCollection<Action>();
            _eventWaitTask = new AutoResetEvent(false);
            _timeOut = 1000;
        }

        public TaskQueue(int timeOut)
        {
            _tasks = new BlockingCollection<Action>();
            _eventWaitTask = new AutoResetEvent(false);
            _timeOut = timeOut;
        }

        public void Start(int maxConcurrent)
        {
            if (maxConcurrent <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxConcurrent));
            }

            lock (_tasks)
            {
                if (_isStart)
                {
                    return;
                }

                _isStart = true;

                _sourceToken?.Dispose();
                _sourceToken = new CancellationTokenSource();

                _workers = new Thread[maxConcurrent];

                for (int i = 0; i < maxConcurrent; i++)
                {
                    _workers[i] = new Thread(new ParameterizedThreadStart(ProcessingTask));
                    _workers[i].Start(_sourceToken.Token);
                }
            }
        }

        public void Add(Action action)
        {
            _tasks.Add(action);
            _eventWaitTask.Set();
        }

        public void Clear()
        {
            _tasks.Clear();
        }

        public void Stop()
        {
            lock (_tasks)
            {
                if (!_isStart)
                {
                    return;
                }

                _isStart = false;
                _sourceToken.Cancel();              

                _eventWaitTask.Set();

                foreach (var worker in _workers)
                {
                    if (!worker.Join(_timeOut))
                    {
                        worker.Abort();
                    }
                }
            }
        }

        private void ProcessingTask(object token)
        {
            while (true)
            {
                _eventWaitTask.WaitOne();

                if (((CancellationToken)token).IsCancellationRequested)
                {
                    _eventWaitTask.Set();
                    break;
                }

                if (_tasks.Count > 0)
                {
                    _eventWaitTask.Set();

                    if (_tasks.TryTake(out var task))
                    {
                        task?.Invoke();
                    }
                }
            }
        }

        public void Dispose()
        {
            Stop();
            Clear();
            _eventWaitTask?.Close();
            _tasks?.Dispose();
            _sourceToken?.Dispose();
            _workers = null;
        }
    }
}