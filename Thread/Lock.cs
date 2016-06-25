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
    public partial class Lock : Form
    {//http://www.cnblogs.com/myprogram/p/4924335.html
        public Lock()
        {
            InitializeComponent();
        }
        private void Lock_Load(object sender, EventArgs e)
        {//通过锁来实现同步


         //排它锁主要用来保证，在一段时间内，只有一个线程可以访问某一段代码。
         //两种主要类型的排它锁是lock和Mutex。Lock和Mutex相比构造起来更方便，
         //运行的也更快。但是Mutex可以在同一个机器上的不同进程使用。
        }
        private void btnLockMonitor_Click(object sender, EventArgs e)
        {

            //Monitor.Enter和Monitor.Exit
            //C#中的lock关键字，实际上是Monitor.Enter,Monitor.Exist的一个简写。
            //在.NET 1.0,2.0,3.0 版本的c#中，
            //lock会被编译成如下代码：

            //Monitor.Enter(_locker);
            //try
            //{
            //    if (_val2 != 0)
            //        Console.WriteLine(_val1 / _val2);
            //    _val2 = 0;
            //}
            //finally
            //{
            //    Monitor.Exit(_locker);
            //}

            //如果你没有调用Monitor.Enter而直接调用Monitor.Exit会引发异常。
        }
        
        private void btnLockTaken_Click(object sender, EventArgs e)
        {
            //LockTaken版本：
            //想象一下上面这段代码，如果再Monitor.Enter之后，try之前，线程出现了异常(比如被终止)，
            //在这种情况下，finally中的Exit方法就永远不会被执行，也就导致了这个锁不会被释放。
            //为了避免这种情况，CLR 4.0的设计者重载了Monitor.Enter方法：
            //public static void Enter(object obj, ref bool lockTaken);


            //如果当前线程由于某些异常导致锁没有被获取到，lockTake值会为false，
            //因此在CLR 4.0中，lock会被解释成如下代码：


            //bool lockTaken = false;
            //try
            //{ 
            //    Monitor.Enter(_locker, ref lockTaken); 
            //        // Do your stuff...
            // }
            //finally
            //{
            //    if (lockTaken)
            //        Monitor.Exit(_locker);
            //}


            //TryEnter
            //Monitor也提供了了一个TryEnter方法，允许你设置一个超时时间，避免当前线程长时间获取不到锁而一直等待。


            //选择正确的同步对象


            //你需要选择一个对所有线程都可见的对象进行lock(obj)来确保程序能够按照你的意图执行。
            //如果比不了解C#语言中的某些特性，lock可能不会按照你 期望来执行。

            //1 由于字符串的驻留机制，lock("string")不是一个好的选择
            //2 Lock一个值类型不是一个好的选择
            //3 Lock(typeof(..))不是一个好的选择，因为System.Type的特性
        }
        private void btnWhenUseLock_Click(object sender, EventArgs e)
        {
            //什么时候使用lock
            //一个基本的规则，你需要对任意的写操作，或者可修改的字段进行lock。
            //即使是一个赋值操作，或者累加操作，你也不能假设他是线程安全的。

            //例如下面代码不是线程安全的：
            //class ThreadUnsafe
            //{
            //    static int _x;
            //    static void Increment() { _x++; }
            //    static void Assign() { _x = 123; }
            //}

            //你需要这样写：
            //class ThreadSafe
            //{
            //    static readonly object _locker = new object();
            //    static int _x;
            //    static void Increment() { lock (_locker) _x++; }
            //    static void Assign() { lock (_locker) _x = 123; }
            //}

            //如果你看过一些BCL类库里面的实现，你可以能会发现，
            //某些情况下会使用InterLocked类，而不是lock，我们会在后面介绍。

        }

        private void btnReentrant_Click(object sender, EventArgs e)
        {
            //关于嵌套锁或者reentrant
            //你在阅读一些文档的时候，有的文档可能会说lock或者Monitor.Enter是reentrant(可重入的)，
            //那么我们如何理解reentrant呢？

            //想象下以下代码：
            //lock (locker)
            //    lock (locker)
            //        lock (locker)
            //                    {
            //                        // Do something...
            //                    }


            //或者是：

            //Monitor.Enter(locker); Monitor.Enter(locker); Monitor.Enter(locker);
            //  // Do something...
            //Monitor.Exit(locker); Monitor.Exit(locker); Monitor.Exit(locker);
            //这种情况下，只有在最后一个exit执行后，或者执行了相应次数的Exit后，locker才是可获取的状态。
        }


        private void btnMutex_Click(object sender, EventArgs e)
        {
            //Mutex
            //Mutex像c#中的lock一样，但是在不同的进程中仍然可以使用。
            //换句话说，Mutex是一个计算机级别的锁。
            //因此获取这样一个锁要比Monitor慢很多。

            //示例代码：
            using (var mutex = new Mutex(false, "oreilly.com OneAtATimeDemo"))
            {
                // Wait a few seconds if contended, in case another instance
                // of the program is still in the process of shutting down.
                if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
                {
                    Console.WriteLine("Another app instance is running. Bye!");
                    return;
                }
                RunProgram();
            }     
          }
        
        private void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }

        private void btnSemaphore_Click(object sender, EventArgs e)
        {
            //Semaphore
            //Monitor和Mutex都是排他锁，Semaphore我们常用的另外一种非排他的锁。

            //我们用它来实现这样一个例子：一个酒吧，最多能容纳3人，如果客满则需要等待，
            //有客人离开，等待的人随时可以进来。

            //示例代码：

            //使用Semaphore需要调用者来控制访问资源，调用WaitOne来获取资源，
            //通过Release来释放资源。开发者有责任确保资源能够正确释放。

            //Semaphore在限制同步访问的时候非常有用，
            //它不会像Monitor或者Mutex那样当一个线程访问某些资源时，
            //其它所有线程都需要等，而是设置一个缓冲区，
            //允许最多多少个线程同时进行访问。

            //Semaphore也可以像Mutex一样，跨进程进行同步。
        }
    
    }

    class TheClub      // No door lists!
    {
        static Semaphore _sem = new Semaphore(3,3);    // Capacity of 3

        static void Main333()
        {
            for (int i = 1; i <= 5; i++)
                new System.Threading.Thread(Enter).Start(i);

            Console.ReadLine();
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            _sem.WaitOne();
            Console.WriteLine(id + " is in!");           // Only three threads
            System.Threading.Thread.Sleep(1000 * (int)id);               // can be here at
            Console.WriteLine(id + " is leaving");       // a time.
            _sem.Release();
        }
    }
}
