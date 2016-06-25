using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{

    public class ProducerConsumerQueue : IDisposable
    {
        EventWaitHandle _wh = new AutoResetEvent(false);
        System.Threading.Thread _worker;
        readonly object _locker = new object();
        Queue<string> _tasks = new Queue<string>();

        public ProducerConsumerQueue()
        {
            _worker = new System.Threading.Thread(Work);
            _worker.Start();
        }

        public void EnqueueTask(string task)
        {
            lock (_locker) _tasks.Enqueue(task);
            _wh.Set();
        }

        public void Dispose()
        {
            EnqueueTask(null);     // Signal the consumer to exit.
            _worker.Join();         // Wait for the consumer's thread to finish.
            _wh.Close();            // Release any OS resources.
        }

        void Work()
        {
            while (true)
            {
                string task = null;
                lock (_locker)
                  if (_tasks.Count > 0)
                    {
                        task = _tasks.Dequeue();
                        if (task == null) return;
                    }
                if (task != null)
                {
                    Console.WriteLine("Performing task: " + task);
                    System.Threading.Thread.Sleep(1000);  // simulate work...
                }
                else
                    _wh.WaitOne();         // No more tasks - wait for a signal
            }
        }
    }
}
