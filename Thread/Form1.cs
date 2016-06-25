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
    public partial class Form1 : Form
    {//http://www.cnblogs.com/myprogram/p/4892868.html
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateThread_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new ThreadStart(Go));
            t.Start();//run go() on the new thread
            //--------------------------------------------------------------
            //Go();//run go() in the main thread
        }

        private void Go()
        {
            Console.WriteLine("hello thread");
        }

        private void btnThreadPara_Click(object sender, EventArgs e)
        {
            //不好
            for(int i = 0;i<10;i++)
            {//由于i变量的共享，在运行的时候输出会有问题
                new System.Threading.Thread(() => Console.Write(i)).Start();
            }

            //好
            for (int i = 0; i < 10; i++)
            {//由于i变量的共享，在运行的时候输出会有问题
                int temp = i;
                new System.Threading.Thread(() => Console.Write(temp)).Start();
            }
        }

        private void btnThreadException_Click(object sender, EventArgs e)
        {
            //我们不能这样做
            try
            {
                new System.Threading.Thread(Go).Start();
            }
            catch(Exception ex)
            {
                Console.Write("Exception" + ex.Message + ex.StackTrace);
            }

            //而是这样做
            new System.Threading.Thread(Go2).Start();
        }
        private void Go2()
        {
            try
            {
                //...
                throw null;// the NullReferenceException will get caught below 
                //....
            }
            catch (Exception ex)
            {
                //Typically log the exception ,and/or signal another thread
                // that we've come unstuck
                //'....
            }
        }


        private void Go3()
        {
            //System.Thread线程的成员
            //System.Threading.Thread帮助我们实现了一些线程的基本操作，如：
            //属性名称
            //说明
            //CurrentContext
            //获取线程正在其中执行的当前上下文。
            //CurrentThread
            //获取当前正在运行的线程。
            //ExecutionContext
            //获取一个 ExecutionContext 对象，该对象包含有关当前线程的各种上下文的信息。
            //IsAlive
            //获取一个值，该值指示当前线程的执行状态。
            //IsBackground
            //获取或设置一个值，该值指示某个线程是否为后台线程。
            //IsThreadPoolThread
            //获取一个值，该值指示线程是否属于托管线程池。
            //ManagedThreadId
            //获取当前托管线程的唯一标识符。
            //Name
            //获取或设置线程的名称。
            //Priority
            //获取或设置一个值，该值指示线程的调度优先级。
            //ThreadState
            //获取一个值，该值包含当前线程的状态。



            //方法名称
            //说明
            //Abort()
            //终止本线程。
            //GetDomain()
            //返回当前线程正在其中运行的当前域。
            //GetDomainId()
            //返回当前线程正在其中运行的当前域Id。
            //Interrupt()
            //中断处于 WaitSleepJoin 线程状态的线程。
            //Join()
            //已重载。阻塞调用线程，直到某个线程终止时为止。
            //Resume()
            //继续运行已挂起的线程。
            //Start()
            //执行本线程。
            //Suspend()
            //挂起当前线程，如果当前线程已属于挂起状态则此不起作用
            //Sleep()
            //把正在运行的线程挂起一段时间。


            //前台线程vs后台线程

            //这里我们单独提一下前台线程和后台线程。在CLR中，线程分为前台线程和后台线程，当所有前台的线程执行完之后，
            //CLR会强制结束所有正在运行的后台线程，并且不会出现任何异常。

            //因此你应该使用前台线程来做一些必须完成的任务，比如把流从内存中写到磁盘上。
            //后台线程可以做一些不那么重要的事情。
            //一旦线程对象的生命周期开始，你就不能修改IsBackground值。

            //由于线程是非常昂贵的资源，我们经常需要控制允许多少线程同时运行，
            //如何控制线程的生命周期，如何管理线程，这里我们引入了线程池的概念。
        }
    }
}
