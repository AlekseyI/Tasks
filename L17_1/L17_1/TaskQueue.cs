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
        private AutoResetEvent _eventWait;
        private AutoResetEvent _eventWait1;
        private List<Thread> _workers;
        private bool _isStart;
        public bool _isStop;
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
            _workers = new List<Thread>();
            _eventWait = new AutoResetEvent(false);
            _eventWait1 = new AutoResetEvent(true);
            _timeOut = 1000;
            _isStop = true;
        }

        public TaskQueue(int timeOut)
        {
            _tasks = new BlockingCollection<Action>();
            _workers = new List<Thread>();
            _eventWait = new AutoResetEvent(false);
            _eventWait1 = new AutoResetEvent(true);
            _timeOut = timeOut;
            _isStop = true;
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

                var threadStart = new Thread(() =>
                {
                    _eventWait1.WaitOne();

                    _isStart = true;
                    _isStop = false;

                    for (int i = 0; i < maxConcurrent; i++)
                    {
                        var worker = new Thread(ProcessingTask);
                        _workers.Add(worker);
                        worker.Start();
                    }

                    _eventWait1.Set();
                });

                threadStart.Start();
                threadStart.Join();
            }
        }

        public void Add(Action action)
        {
            _tasks.Add(action);
            _eventWait.Set();
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

                var threadStop = new Thread(() =>
                {
                    _eventWait1.WaitOne();

                    _isStop = true;
                    _isStart = false;

                    _eventWait.Set();

                    foreach (var worker in _workers)
                    {
                        if (!worker.Join(_timeOut))
                        {
                            worker.Abort();
                        }
                    }

                    _workers.Clear();

                    _eventWait1.Set();
                });

                threadStop.Start();
                threadStop.Join();
            }
        }

        private void ProcessingTask()
        {
            while (true)
            {
                _eventWait.WaitOne();

                if (_isStop)
                {
                    _eventWait.Set();
                    break;
                }

                if (_tasks.Count > 0)
                {
                    _eventWait.Set();
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
            _eventWait.Close();
            _eventWait.Close();
            _tasks.Dispose();
            _workers = null;
        }
    }
}