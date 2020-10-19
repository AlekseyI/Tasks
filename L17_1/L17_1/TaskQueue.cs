using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace L17_1
{
    public class TaskQueue : IJobExecutor, IDisposable
    {
        private BlockingCollection<Action> _tasks;
        private AutoResetEvent _eventWaitTask;
        private AutoResetEvent _eventWaitStartStop;
        private Thread[] _workers;
        private bool _isStart;
        private bool _isStop;
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
            _eventWaitStartStop = new AutoResetEvent(true);
            _timeOut = 1000;
            _isStop = true;
        }

        public TaskQueue(int timeOut)
        {
            _tasks = new BlockingCollection<Action>();
            _eventWaitTask = new AutoResetEvent(false);
            _eventWaitStartStop = new AutoResetEvent(true);
            _timeOut = timeOut;
            _isStop = true;
        }

        public void Start(int maxConcurrent)
        {
            if (maxConcurrent <= 0)
            {
                throw new ArgumentOutOfRangeException("maxConcurrent");
            }

            lock (_tasks)
            {
                if (_isStart)
                {
                    return;
                }

                _eventWaitStartStop.WaitOne();

                _isStart = true;
                _isStop = false;

                _workers = new Thread[maxConcurrent];

                for (int i = 0; i < maxConcurrent; i++)
                {
                    _workers[i] = new Thread(ProcessingTask);
                    _workers[i].Start();
                }

                _eventWaitStartStop.Set();
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
                if (_isStop)
                {
                    return;
                }

                _eventWaitStartStop.WaitOne();

                _isStop = true;
                _isStart = false;

                _eventWaitTask.Set();

                foreach (var worker in _workers)
                {
                    if (!worker.Join(_timeOut))
                    {
                        worker.Abort();
                    }
                }

                _eventWaitStartStop.Set();
            }
        }

        private void ProcessingTask()
        {
            while (true)
            {
                _eventWaitTask.WaitOne();

                if (_isStop)
                {
                    _eventWaitTask.Set();
                    break;
                }

                if (_tasks.Count > 0)
                {
                    _eventWaitTask.Set();

                    Action task = null;

                    if (_tasks.TryTake(out task))
                    {
                        if (task != null)
                        {
                            task.Invoke();
                        }
                    }
                }
            }
        }

        public void Dispose()
        {
            Stop();
            Clear();
            _eventWaitTask.Close();
            _eventWaitStartStop.Close();
            _tasks.Dispose();
            _workers = null;
        }
    }
}