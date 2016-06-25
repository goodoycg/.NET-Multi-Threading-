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
    public partial class Task : Form
    {//http://www.cnblogs.com/myprogram/p/4902738.html
        public Task()
        {
            InitializeComponent();
        }

        private void Task_Load(object sender, EventArgs e)
        {
            //上一节我们介绍了线程池相关的概念以及用法。
            //我们可以发现ThreadPool.QueueUserWorkItem是一种起了线程之后就不管了的做法。
            //但是实际应用过程，我们往往会有更多的需求，
            //比如如果更简单的知道线程池里面的某些线程什么时候结束，
            //线程结束后如何执行别的任务。Task可以说是ThreadPool的升级版，
            //在线程任务调度，并行编程中都有很大的作用。
        }

        private void btnInitCreatTask_Click(object sender, EventArgs e)
        { //使用lambda表达式创建Task
            System.Threading.Tasks.Task.Factory.StartNew(() => Console.WriteLine("Hello from a task!"));
            var task = new System.Threading.Tasks.Task(() => Console.Write("Hello"));
            task.Start();



        }

        private void btnDefaultParaCreateTask_Click(object sender, EventArgs e)
        {
            var task = System.Threading.Tasks.Task.Factory.StartNew(state => Greet("Hello"), "Greeting");
            Console.WriteLine(task.AsyncState);   // Greeting
            task.Wait();
            //这种方式的一个优点是，
            //task.AsyncState作为一个内置的属性，
            //可以在不同线程中获取参数的状态。
        }
        private void Greet(string message) { Console.Write(message); }

        private void btnCreateTaskOfOpentions_Click(object sender, EventArgs e)
        {
            //创建Task的时候，我们可以指定创建Task的一些相关选项。
            
            //
            //在.Net 4.0中，有如下选项：
            //

            //LongRunning
            //用来表示这个Task是长期运行的，这个参数更适合block线程。LongRunning线程一般回收的周期会比较长，因此CLR可能不会把它放到线程池中进行管理。

            //PreferFairness
            //表示让Task尽量以公平的方式运行，避免出现某些线程运行过快或者过慢的情况。

            //AttachedToParent
            //表示创建的Task是当前线程所在Task的子任务。这一个用途也很常见。

            //下面的代码是创建子任务的示例：

            System.Threading.Tasks.Task parent = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Console.WriteLine("I am a parent");
                System.Threading.Tasks.Task.Factory.StartNew(() =>        // Detached task
                {
                    Console.WriteLine("I am detached");
                });
                System.Threading.Tasks.Task.Factory.StartNew(() =>        // Child task
                {
                    Console.WriteLine("I am a child");
                }, TaskCreationOptions.AttachedToParent);
            });
            
            parent.Wait();

            Console.ReadLine();
            //如果你等待你一个任务结束，你必须同时等待任务里面的子任务结束。这一点很重要，尤其是你在使用Continue的时候。(后面会介绍)

        }

        private void btnWaitTask_Click(object sender, EventArgs e)
        {//在ThreadPool内置的方法中无法实现的等待，
         //在Task中可以很简单的实现了：
            var t1 = System.Threading.Tasks.Task.Run(() => Go(null));
            var t2 = System.Threading.Tasks.Task.Run(() => Go(123));
            System.Threading.Tasks.Task.WaitAll(t1, t2);//等待所有Task结束
            //Task.WaitAny(t1, t2);//等待任意Task结束
        }
        private void Go(object data)   // data will be null with the first call.
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Hello from the thread pool! " + data);

            //注意：

            //当你调用一个Wait方法时，当前的线程会被阻塞，直到Task返回。
            //但是如果Task还没有被执行，这个时候系统可能会用当前的线程来执行调用Task，
            //而不是新建一个，这样就不需要重新创建一个线程，并且阻塞当前线程。
            //这种做法节省了创建新线程的开销，也避免了一些线程的切换。
            //但是也有缺点，当前线程如果和被调用的Task同时想要获得一个lock，
            //就会导致死锁。
        }

        private void btnTaskException_Click(object sender, EventArgs e)
        {
            //当等待一个Task完成的时候（调用Wait或者或者访问Result属性的时候），
            //Task任务中没有处理的异常会被封装成AggregateException重新抛出，
            //InnerExceptions属性封装了各个Task没有处理的异常。

            int x = 0;
            System.Threading.Tasks.Task<int> calc = System.Threading.Tasks.Task.Factory.StartNew(() => 7 / x);
            try
            {
                Console.WriteLine(calc.Result);
            }
            catch (AggregateException aex)
            {
                Console.Write(aex.InnerException.Message);  // Attempted to divide by 0
            }

        }

        private void btnSubTask_Click(object sender, EventArgs e)
        {//对于有父子关系的Task，子任务未处理的异常会逐层传递到父Task，并且最后包装在AggregateException中。
            TaskCreationOptions atp = TaskCreationOptions.AttachedToParent;
            var parent = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                System.Threading.Tasks.Task.Factory.StartNew(() =>   // Child
                {
                    System.Threading.Tasks.Task.Factory.StartNew(() => { throw null; }, atp);   // Grandchild
                }, atp);
            });

            // The following call throws a NullReferenceException (wrapped
            // in nested AggregateExceptions):
            parent.Wait();
        }

        private void btnCancelTask_Click(object sender, EventArgs e)
        {//如果想要支持取消任务，那么在创建Task的时候，
            //需要传入一个CancellationTokenSouce
            var cancelSource = new CancellationTokenSource();
            CancellationToken token = cancelSource.Token;

            System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                // Do some stuff...
                token.ThrowIfCancellationRequested();  // Check for cancellation request
                // Do some stuff...
            }, token);
            cancelSource.Cancel();

            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is OperationCanceledException)
                    Console.Write("Task canceled!");
            }

            Console.ReadLine();
        }

        private void btnTaskContinuationsRun_Click(object sender, EventArgs e)
        {//任务调度也是常见的需求，Task支持一个任务结束之后执行另一个任务。
            System.Threading.Tasks.Task task1 = System.Threading.Tasks.Task.Factory.StartNew(() => Console.Write("antecedant.."));
            System.Threading.Tasks.Task task2 = task1.ContinueWith(task => Console.Write("..continuation"));

            //Task也有带返回值的重载，示例代码如下：
            System.Threading.Tasks.Task.Factory.StartNew<int>(() => 8)
                .ContinueWith(ant => ant.Result * 2)
                .ContinueWith(ant => Math.Sqrt(ant.Result))
                .ContinueWith(ant => Console.WriteLine(ant.Result));   // output 4
        }

        private void btnTaskSub_Click(object sender, EventArgs e)
        {//前面提到了，当你等待一个任务的时候，同时需要等待它的子任务完成。

            //下面代码演示了带子任务的Task：

            System.Threading.Tasks.Task<int[]> parentTask = System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                int[] results = new int[3];

                System.Threading.Tasks.Task t1 = new System.Threading.Tasks.Task(() =>
                { System.Threading.Thread.Sleep(3000); results[0] = 0; }, TaskCreationOptions.AttachedToParent);
                System.Threading.Tasks.Task t2 = new System.Threading.Tasks.Task(() =>
                { System.Threading.Thread.Sleep(3000); results[1] = 1; }, TaskCreationOptions.AttachedToParent);
                System.Threading.Tasks.Task t3 = new System.Threading.Tasks.Task(() =>
                { System.Threading.Thread.Sleep(3000); results[2] = 2; }, TaskCreationOptions.AttachedToParent);

                t1.Start();
                t2.Start();
                t3.Start();

                return results;
            });

            System.Threading.Tasks.Task finalTask = parentTask.ContinueWith(parent =>
            {
                foreach (int result in parent.Result)
                {
                    Console.WriteLine(result);
                }
            });

            finalTask.Wait();
            Console.ReadLine();
            //这段代码的输出结果是： 1,2,3
            //FinalTask会等待所有子Task结束后再执行。

        }

        private void btnTaskFactory_Click(object sender, EventArgs e)
        {
            //关于TaskFactory，上面的例子中我们使用了System.Threading.Tasks.Task.Factory属性来快速的创建Task。
            //当然你也可以自己创建TaskFactory，
            //你可以指定自己的TaskCreationOptions，TaskContinuationOptions来使得通过你的Factory创建的Task默认行为不同。

            //.Net中有一些默认的创建Task的方式，由于TaskFactory创建Task的默认行为不同可能会导致一些不容易发现的问题。

            //如在.NET 4.5中，Task加入了一个Run的静态方法：

            //Task.Run(someAction);

            //如果你用这个方法代替上面例子中的Task.Factory.StartNew，就无法得到正确的结果。
            //原因是Task.Run创建Task的行为默认是默认是拒绝添加子任务的。上面的代码等价于：

            //Task.Factory.StartNew(someAction, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

            //你也可以创建具有自己默认行为的TaskFactory。 

            //无论ThreadPool也好，或者Task，微软都是在想进办法来实现线程的重用，来节省不停的创建销毁线程带来的开销。
            //线程池内部的实现可能在不同版本中有不同的机制。如果可能的话，使用线程池来管理线程仍然是建议的选择。


            //我们主要介绍了一下Task的基本用法，在我们编程过程中，有一些使用Task来提升程序性能的场景往往是很相似的，
            //微软为了简化编程，在System.Threading.Tasks.Parallel中封装了一系列的并行类，内部也是通过Task来实现的。



        }
        
        private void btnParallel_Click(object sender, EventArgs e)
        {//在编程过程中，我们经常会用到循环语句：
            for (int i = 0; i < 10; i++)
            {
                DoSomeWork(i);
            }
            //如果循环过程中的工作可以是并行的话，那么我们可以用如下语句：
            Parallel.For(0, 10, i => DoSomeWork(i));


            //我们也经常会使用Foreach来遍历某个集合：
            foreach (var item in collection)
            {
                DoSomeWork(item);
            }


            //如果我们用一个线程池来执行里面的任务，那么我们可以写成：
            Parallel.ForEach(collection, item => DoSomeWork(item));


            //如果你想并行的执行几个不同的方法，你可以：
            Parallel.Invoke(Method1, Method2, Method3);


            //如果你看下后台的实现，你会发现基本都是基于Task的线程池，
            //当然你也可以通过手动创建一个Task集合，然后等待所有的任务结束来实现同样的功能。

            //上面的Parallel.For和Parallel.Forach方法并不以为这你可以寻找你代码里面所有用到For和Foreach方法，
            //并且替代他们，因为每一个任务都会分配一个委托，并且在线程池里执行，
            //如果委托里面的任务是线程不安全的，你可能还需要lock来保证线程安全，使用lock本身就会造成性能上的损耗。


            //如果每一个任务都是需要长时间执行并且线程安全的，/Parallel会给你带来不错的性能提升。

            //对于短任务，或者线程不安全的任务，你需要权衡下，你是否真的需要使用Parallel。
        }
        List<int> collection = new List<int>();
        private void DoSomeWork(int i)
        {
            //
        }
        private void Method1()
        {
            //
        }
        private void Method2()
        {
            //
        }
        private void Method3()
        {
            //
        }
        
    }
}
