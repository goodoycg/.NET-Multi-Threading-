# .NET-Multi-Threading-
.NET Multi-Threading 

1 概念
1.1 创建一个线程
1.2 线程异常的捕获
1.3 使用匿名方法的闭包特性可以很方便的为线程传递参数

2 线程池
2.1 线程池
2.2 Task来获得线程的返回值
2.3 使用Task来等待线程结束
2.4 阻塞的方式执行异步委托
2.5 非阻塞的方式执行异步委托

3 使用Task
3.1 创建并且初始化Task
3.2 用默认参数的委托创建Task
3.3 指定创建Task的一些相关选项
3.4 等待Task
3.5 Task异常处理
3.6 有父子关系的Task
3.7 取消Task
3.8 任务的连续执行
3.9 子任务
3.10 TaskFactory
3.11 Parallel的For，Foreach，Invoke 方法

4 使用锁进行同步
4.1 通过锁来实现同步 Monitor.Enter和Monitor.Exit
4.2 LockTaken版本：
4.3 什么时候使用lock
4.4 关于嵌套锁或者reentrant
4.5 Mutex
4.6 Semaphore

5 使用信号量进行同步
5.1 使用EventWaitHandle信号量进行同步
5.2 双向信号灯
5.3 生产消费队列
5.4 一个新的类BlockingCollection实现了类似生产者消费者队列的功能。
5.5 ManualResetEvent
5.6 CountdownEvent
5.7 创建跨进程的EventWaitHandle

6 使用MemoryBarrier，Volatile进行同步
6.1 MemoryBarriers
6.2 volatile关键字
6.3 VolatileRead和VolatileWrite
6.4 Interlocked
