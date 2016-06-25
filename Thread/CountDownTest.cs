using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{

    public class CountDownTest
    {
        static CountdownEvent _countdown = new CountdownEvent(3);

        static void Main4()
        {//CountdownEvent的使用和ManualEvent正好相反，是多个线程共同唤醒一个线程。

            new System.Threading.Thread(SaySomething).Start("I am thread 1");
            new System.Threading.Thread(SaySomething).Start("I am thread 2");
            new System.Threading.Thread(SaySomething).Start("I am thread 3");

            _countdown.Wait();   
            // 当前线程被阻塞，直到收到 _countdown发送的三次信号
            Console.WriteLine("All threads have finished speaking!");

            Console.ReadLine();
        }

        static void SaySomething(object thing)
        {
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine(thing);
            _countdown.Signal();
        }
    }
}
