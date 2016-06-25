using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Thread
{
    public partial class ThreadPoolForm2 : Form
    {//http://www.cnblogs.com/myprogram/p/4893059.html
        public ThreadPoolForm2()
        {
            InitializeComponent();
        }

        private void ThreadPoolForm2_Load(object sender, EventArgs e)
        {
            //由于线程的创建，销毁都是需要耗费大量资源和时间的，开发者应该非常节约的使用线程资源。
            //最好的办法是使用线程池，线程池能够避免当前进行中大量的线程导致操作系统不停的进行线程切换，
            //当线程数量到达了我们设置的上限，线程会自动排队等待，当线程资源可用时，队列中的线程任务会依次执行，
            //如果没有排队等候的资源，线程会变为闲置状态。
        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(Go);
            ThreadPool.QueueUserWorkItem(Go,123);
            Console.ReadLine();
            //这种做法可以让我们不用那么复杂的去实现创建，重用线程的逻辑，
            //但是也有一些限制，比如由他内置的方法，
            //我们不知道什么时候线程池里面的任务会结束，
            //也不能获取线程的返回值。为了解决这些问题，
            //微软引入了一个新的概念。Task

            //下面这些实现都是等价的。
            //Task本身实现了很多ThreadPool不能做的事情。
            ThreadPool.QueueUserWorkItem(Go);
            new System.Threading.Tasks.Task(Go, null).Start();
            System.Threading.Tasks.Task.Run(() => Go(null));
        }
        private void Go(object data)
        {//data will be null with the first call
            Console.WriteLine("Hello from the thread pool!" + data);
        }

        private void btnTaskGetReturnValue_Click(object sender, EventArgs e)
        {
            Task<string> task = System.Threading.Tasks.Task.Factory.StartNew<string>(() => DownloadString("http://www.cnblogs.com"));
            RunSomeOtherMethod();

            string result = task.Result;
        }

        private void RunSomeOtherMethod()
        {

        }
        private string DownloadString(string uri)
        {
            using (var wc = new System.Net.WebClient())
                return wc.DownloadString(uri);
        }

        private void btnTaskWaitThreadOver_Click(object sender, EventArgs e)
        {
            var t1 = System.Threading.Tasks.Task.Run(() => GoWait(null));
            var t2 = System.Threading.Tasks.Task.Run(() => GoWait(123));
            System.Threading.Tasks.Task.WaitAll(t1, t2);
        }
        private void GoWait(object data)
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Hello from the thread pool!" + data);
        }

        private void btnAsyncDelegate_Click(object sender, EventArgs e)
        {//阻塞的方式执行异步委托

            //异步委托

            //ThreadPool.QueueUserWorkItem没有提供一种简单的机制来获取线程的返回值。异步委托解决了这个问题，支持了传入一系列的参数。
            //此外，异步委托中没有处理的异常会很方便的在调用线程的重新抛出（在调用EndInvoke的时候），因此不需要显示的处理。

            //通过异步委托来执行任务主要分一下几步：

            //初始化并声明一个你想要执行的委托
            //在委托上调用BeginInvoke，把返回值保存为IAsyncResult中
            //调用BeginInvoke不会阻塞当前线程，因此你可以在调用完之后执行其他你想要同步的操作

            //当你需要获取委托的返回值时，调用EndInvoke方法，把IAsyncResult传入EndInvoke中

            //
            //阻塞的方式执行异步委托
            //

            //定义一个委托
            Func<string, int> method = Work;
            IAsyncResult cookie = method.BeginInvoke("test", null, null);
            //
            //这里面，我们可以同时执行其他操作。
            //

            //这里面我们调用EndInvoke来获取委托执行后的返回值，如果委托还没有执行结束，
            //当前线程会等待委托返回

            int result = method.EndInvoke(cookie);
            Console.WriteLine("String lenght is " + result);
            //EndInvoke主要做3件事： 
            //1. 等待异步委托完成 
            //2. 接收返回值 
            //3. 把异步线程中未处理的异常在当前线程中重新抛出。
        }
        private int Work(string s) { return s.Length; }

        private void btnAsyncDelegate2_Click(object sender, EventArgs e)
        {
            //
            //非阻塞的方式执行异步委托
            //

            //定义一个委托
            Func<string, int> method = Work;
            IAsyncResult cookie = method.BeginInvoke("test", Done, method);
            Console.ReadLine();
            //你也可以在调用BeginInvoke的时候指定一个回调方法，
            //这个方法会在异步委托结束的时候自动调用。
            //这样异步委托就像是一个后台线程一样自动执行，不需要主线程等待。
            //只需要在BeginInvoke的时候做一些额外的操作即可实现这种操作。


        }
        private void Done(IAsyncResult cookie)
        {
            var target = (Func<string, int>)cookie.AsyncState;
            int result = target.EndInvoke(cookie);
            Console.WriteLine("String length is:" + result);


            //关于线程池
            //Jeffery在C# via CLR Chapter27中针对线程池的使用给出了一些建议。
            //目前我们允许开发者来指定一个线程池的最大线程数。
            //但是事实证明，我们往往不应该为一个线程池指定线程的上限，
            //否则可能会出现程序死锁或者饿死的状态。

            //比如你可能设置了1000个线程，
            //但是某一时刻正好有第1001个线程需要等待所有线程结束才能执行，
            //这种情况如果你限制了线程池线程的个数，就会出现死锁。
            //从开发的另一个角度说，你也不应该限制一个进程使用多少资源，
            //比如一个进程可以使用多少内存，使用多少带宽.
             
            //因此虽然目前你可以通过GetMaxThreads， SetMaxThreads，GetMinThreads，
            //SetMinThreads ，GetAvailableThreads来进行线程个数的限制，
            //但是他仍然不建议大家这样做。
            //这些限制可能会让你的程序运行的更慢。
        }
    }
}
