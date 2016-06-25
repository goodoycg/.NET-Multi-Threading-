using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread
{
    public partial class MemoryBarrier : Form
    {//http://www.cnblogs.com/myprogram/p/4940219.html
        public MemoryBarrier()
        {
            InitializeComponent();
        }

        private void MemoryBarrier_Load(object sender, EventArgs e)
        {
            //上一节介绍了使用信号量进行同步，
            //本节主要介绍一些非阻塞同步的方法。
            //本节主要介绍MemoryBarrier，volatile,Interlocked。

        }

        private void buttonMemoryBarriers_Click(object sender, EventArgs e)
        {
            //class Foo  如果方法A和方法B同时在两个不同线程中运行，
            //控制台可能输出0吗？答案是可能的，有以下两个原因：

            //编译器，CLR或者CPU可能会更改指令的顺序来提高性能
            //编译器，CLR或者CPU可能会通过缓存来优化变量，这种情况下对其他线程是不可见的。
            //最简单的方式就是通过MemoryBarrier来保护变量，
            //来防止任何形式的更改指令顺序或者缓存。
            //调用Thread.MemoryBarrier会生成一个内存栅栏，


            //我们可以通过以下的方式解决上面的问题：class Foo2

            //class Foo class Foo2
            //上面的例子中，barrier1和barrier3用来保证指令顺序不会改变，
            //barrier2和barrier4用来保证值变化不被缓存。
            //一个好的处理方案就是我们在需要保护的变量前后分别加上MemoryBarrier。

            //在c#中，下面的操作都会生成MemoryBarrier：

            //Lock语句(Monitor.Enter, Monitor.Exit)
            //所有Interlocked类的方法
            //线程池的回调方法
            //Set或者Wait信号
            //所有依赖于信号灯实现的方法，如starting或waiting 一个Task
            //因为上面这些行为，这段代码实际上是线程安全的：

            //int x = 0;
            //System.Threading.Tasks.Task t = System.Threading.Tasks.Task.Factory.StartNew(() => x++);
            //t.Wait();
            //Console.WriteLine(x);    // 1


            //在你自己的程序中，你可能重现不出来上面例子所说的情况。
            //事实上，从msdn上对MomoryBarrier的解释来看，
            //只有对顺序保护比较弱的多核系统才需要用到MomoryBarrier。
            //但是有一点需要注意：
            //多线程去修改变量并且不使用任何形似的锁或者内存栅栏是会带来一定的麻烦的。

            //下面一个例子能够很好的说明上面的观点
            //(在你的VisualStudio中，选择Release模式，并且Start Without Debugging重现这个问题)：

            //bool complete = false;
            //var t = new System.Threading.Thread(() =>
            //{
            //    bool toggle = false;
            //    while (!complete) toggle = !toggle;
            //});
            //t.Start();
            //System.Threading.Thread.Sleep(1000);
            //complete = true;
            //t.Join();        // Blocks indefinitely

            ///这个程序永远不会结束，因为complete变量被缓存在了CPU寄存器中。
            //在while循环中加入Thread.MemoryBarrier可以解决这个问题。

        }

        private void buttonvolatile_Click(object sender, EventArgs e)
        {
            //volatile关键字

            //另外一种更高级的方式来解决上面的问题，
            //那就是考虑使用volatile关键字。
            //Volatile关键字告诉编译器在每一次读操作时生成一个fence，
            //来实现保护保护变量的目的。具体说明可以参见msdn的介绍
        }

        private void buttonVolatileRead2VolatileWrite_Click(object sender, EventArgs e)
        {
            //VolatileRead和VolatileWrite

            //Volatile关键字只能加到类变量中。
            //本地变量不能被声明成volatile。
            //这种情况你可以考虑使用System.Threading.Volatile.Read方法。
            //我们看一下System.Threading.Volatile源码如何实现这两个方法的：

            //public static bool Read(ref bool location)
            //{
            //    bool flag = location;
            //System.Threading.Thread.MemoryBarrier();
            //    return flag;
            //}
            //public static void Write(ref bool location, bool value)
            //{
            //System.Threading.Thread.MemoryBarrier();
            //    location = value;
            //}

            //一目了然，通过MemoryBarrier来实现的，
            //但是他只在读操作的后面和写操作的前面加了MemoryBarrier，
            //那么你应该考虑，如果你先使用Volatile.Write
            //再使用Volatile.Read是不是可能有问题呢？

            //c#中ConcurrentDictionary中使用了Volatile类来保护变量，
            //有兴趣的读者可以看看c#的开发者是如何使用这个方法来保护变量的。
    }

        private void buttonInterlocked_Click(object sender, EventArgs e)
        {
            //Interlocked

            //使用MemoryBarrier并不总是一个好的解决方案，
            //尤其在不需要锁的情况下。
            //Interlocked方法提供了一些常用的原子操作来避免前面文章提到的一系列的问题。
            //如使用Interlocked.Increment来替代++，
            //Interlocked.Decrement来替代--。
            //Msdn的文档中详细的介绍了相关的用法和原理。
            //C#中的源码里也经常能看见Interlocked相关的使用。
        }
    }

    class Foo
    {
        int _answer;
        bool _complete;

        void A()
        {
            _answer = 123;
            _complete = true;
        }

        void B()
        {
            if (_complete) Console.WriteLine(_answer);
        }
    }

    class Foo2
    {
        int _answer;
        bool _complete;

        void A()
        {
            _answer = 123;
            System.Threading.Thread.MemoryBarrier();    // Barrier 1
            _complete = true;
            System.Threading.Thread.MemoryBarrier();    // Barrier 2
        }

        void B()
        {
            System.Threading.Thread.MemoryBarrier();    // Barrier 3
            if (_complete)
            {
                System.Threading.Thread.MemoryBarrier();       // Barrier 4
                Console.WriteLine(_answer);
            }
        }
    }
}
