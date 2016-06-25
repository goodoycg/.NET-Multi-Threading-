using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
    public class BasicWaitHandle
    {
        static EventWaitHandle _waitHandle = new AutoResetEvent(false);

        private void Main2()
        {
            //使用EventWaitHandle信号量进行同步

            //EventWaitHandle主要用于实现信号灯机制。信号灯主要用于通知等待的线程。
            //主要有两种实现：AutoResetEvent和ManualResetEvent。

            //AutoResetEvent
            //AutoResetEvent从字面上理解是一个自动重置的时间。
            //举个例子，假设有很多人等在门外，AutoResetEvent更像一个十字旋转门，
            //每一次只允许一个人进入，进入之后门仍然是关闭状态。

            //下面的例子演示了使用方式：

            for (int i = 0; i < 3; i++)
                new System.Threading.Thread(Waiter).Start();

            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(1000);                  // Pause for a second...
                Console.WriteLine("通知下一个线程进入");
                _waitHandle.Set();                    // Wake up the Waiter.
            }
            Console.ReadLine();
        }

        private void Waiter()
        {
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("线程 {0} 正在等待", threadId);
            _waitHandle.WaitOne();                // 等待通知
            Console.WriteLine("线程 {0} 得到通知，可以进入", threadId);
        }
    }
}
