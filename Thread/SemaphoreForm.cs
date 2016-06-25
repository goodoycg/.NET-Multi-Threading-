using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread
{
    public partial class SemaphoreForm : Form
    {//http://www.cnblogs.com/myprogram/p/4931164.html
        public SemaphoreForm()
        {
            InitializeComponent();
        }

        private void buttonEventWaitHandle_Click(object sender, EventArgs e)
        {
            //使用EventWaitHandle信号量进行同步

            //EventWaitHandle主要用于实现信号灯机制。信号灯主要用于通知等待的线程。
            //主要有两种实现：AutoResetEvent和ManualResetEvent。

            //AutoResetEvent
            //AutoResetEvent从字面上理解是一个自动重置的时间。
            //举个例子，假设有很多人等在门外，AutoResetEvent更像一个十字旋转门，每一次只允许一个人进入，进入之后门仍然是关闭状态。

            //下面的例子演示了使用方式： BasicWaitHandle 
        }

        private void buttonTwoWaySignaling_Click(object sender, EventArgs e)
        {
            //双向信号灯
            //某些情况下，如果你连续的多次使用Set方法通知工作线程，
            //这个时候工作线程可能还没有准备好接收信号，
            //这样的话后面的几次Set通知可能会没有效果。
            //这种情况下，你需要让主线程得到工作线程接收信息的通知再开始发送信息。
            //你可能需要通过两个信号灯实现这个功能。

            //示例代码：TwoWaySignaling

        }

        private void buttonProducerConsumerQueue_Click(object sender, EventArgs e)
        {
            //生产消费队列
            //生产消费队列是多线程编程里常见的的需求，他的主要思路是：

            //一个队列用来存放工作线程需要用到的数据
            //当新的任务加入队列的时候，调用线程不需要等待工作结束
            //1个或多个工作线程在后台获取队列中数据信息
            //示例代码：ProducerConsumerQueue

            //为了保证线程安全，我们使用lock来保护Queue<string> 集合。
            //我们也显示的关闭了WaitHandle。
        }

        private void buttonBlockingCollection_Click(object sender, EventArgs e)
        {
            

            //在.NET 4.0中，一个新的类BlockingCollection实现了类似生产者消费者队列的功能。

            
            //示例代码：BlockingCollection


        }

        private void buttonManualResetEvent_Click(object sender, EventArgs e)
        {
            //ManualResetEvent
            //ManualResetEvent从字面上看是一个需要手动关闭的事件。
            //举个例子：假设有很多人等在门外，它像是一个普通的门，门开启之后，
            //所有等在门外的人都可以进来，当你关闭门之后，不再允许外面的人进来。

            //示例代码：BasicWaitHandleNEW

            //ManualResetEvent可以在当前线程唤醒所有等待的线程，这一应用非常重要。
        }

        private void buttonCountdownEvent_Click(object sender, EventArgs e)
        {
            //CountdownEvent
            //CountdownEvent的使用和ManualEvent正好相反，
            //是多个线程共同唤醒一个线程。

            //示例代码：CountDownTest
        }

        private void buttonEventWaitHandle2Process_Click(object sender, EventArgs e)
        {//创建跨进程的EventWaitHandle
            //EventWaitHandle的构造方法允许创建一个命名的EventWaitHandle，
            //来实现跨进程的信号量操作。名字只是一个简单的字符串，
            //只要保证不会跟其它进程的锁冲突即可。

            //示例代码：


            EventWaitHandle wh = new EventWaitHandle(false, EventResetMode.AutoReset, "MyCompany.MyApp.SomeName");


            //如果两个进程运行这段代码，信号量会作用于两个进程内所有的线程。
        }

    }
}
