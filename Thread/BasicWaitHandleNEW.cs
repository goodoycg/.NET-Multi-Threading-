using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{
   public class BasicWaitHandleNEW
    {
        static EventWaitHandle _waitHandle = new ManualResetEvent(false);

        static void Main2()
        {
            //为了保证线程安全，我们使用lock来保护Queue<string> 集合。
            //我们也显示的关闭了WaitHandle。

            //在.NET 4.0中，一个新的类BlockingCollection实现了类似生产者消费者队列的功能。

            //ManualResetEvent
            //ManualResetEvent从字面上看是一个需要手动关闭的事件。举个例子：
            //假设有很多人等在门外，它像是一个普通的门，门开启之后，
            //所有等在门外的人都可以进来，当你关闭门之后，不再允许外面的人进来。

            //示例代码：

            //ManualResetEvent可以在当前线程唤醒所有等待的线程，这一应用非常重要。

            for (int i = 0; i < 3; i++)
                new System.Threading.Thread(Waiter).Start();


            System.Threading.Thread.Sleep(1000);                  // Pause for a second...
            Console.WriteLine("门已打开，线程进入");
            _waitHandle.Set();                    // Wake up the Waiter.

            new System.Threading.Thread(Waiter).Start();

            System.Threading.Thread.Sleep(2000);

            _waitHandle.Reset();
            Console.WriteLine("门已关闭，线程阻塞");

            new System.Threading.Thread(Waiter).Start();

            Console.ReadLine();
        }

        static void Waiter()
        {
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("线程 {0} 正在等待", threadId);
            _waitHandle.WaitOne();                // 等待通知
            Console.WriteLine("线程 {0} 得到通知，可以进入", threadId);
        }
    }    
}
