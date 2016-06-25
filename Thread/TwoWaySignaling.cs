using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread
{

    class TwoWaySignaling
    {
        static EventWaitHandle _ready = new AutoResetEvent(false);
        static EventWaitHandle _go = new AutoResetEvent(false);
        static readonly object _locker = new object();
        static string _message;

        static void Main2()
        {
            //双向信号灯
            //某些情况下，如果你连续的多次使用Set方法通知工作线程，
            //这个时候工作线程可能还没有准备好接收信号，
            //这样的话后面的几次Set通知可能会没有效果。
            //这种情况下，你需要让主线程得到工作线程接收信息的通知再开始发送信息。
            //你可能需要通过两个信号灯实现这个功能。

            //示例代码：TwoWaySignaling

            new System.Threading.Thread(Work).Start();

            _ready.WaitOne();                  // 在工作线程准备接收信息之前需要一直等待
            lock (_locker) _message = "床前明月光";
            _go.Set();                         // 通知工作线程开始工作

            _ready.WaitOne();
            lock (_locker) _message = "疑是地上霜";
            _go.Set();
            _ready.WaitOne();
            lock (_locker) _message = "结束";    // 告诉工作线程退出
            _go.Set();

            Console.ReadLine();
        }

        static void Work()
        {
            while (true)
            {
                _ready.Set();                          // 表示当前线程已经准备接收信号
                _go.WaitOne();                         // 工作线程等待通知
                lock (_locker)
                {
                    if (_message == "结束") return;        // 优雅的退出~-~
                    Console.WriteLine(_message);
                }
            }
        }
    }
}
