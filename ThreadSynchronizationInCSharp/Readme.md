## Thread Synchronization in C#
Thread synchronization is a crucial aspect of multi-threaded programming, ensuring that multiple threads can access shared resources without causing data corruption or inconsistencies. In this blog post, we'll explore various thread synchronization techniques in C# using the provided code example.

1. Lock
The lock statement is a simple and effective way to ensure that only one thread can access a critical section of code at a time. It works by acquiring a mutual exclusion lock on a specified object.
```
class AccountLock
{
    private Object thisLock = new Object();
    int balance;
    Random r = new Random();

    public AccountLock(int initial)
    {
        balance = initial;
    }

    int Withdraw(int amount)
    {
        lock (thisLock)
        {
            if (balance >= amount)
            {
                Console.WriteLine("Balance before Withdrawal (Lock) : " + balance);
                Console.WriteLine("Amount to Withdraw : -" + amount);
                balance = balance - amount;
                Console.WriteLine("Balance after Withdrawal : " + balance);
                return amount;
            }
            else
            {
                return 0; // transaction rejected
            }
        }
    }

    public void DoTransactions()
    {
        for (int i = 0; i < 100; i++)
        {
            Withdraw(r.Next(1, 100));
        }
    }
}

```

In this example, the lock statement ensures that only one thread can execute the Withdraw method at a time, preventing race conditions.

2. Monitor
The Monitor class provides a more flexible way to achieve thread synchronization. It offers methods to acquire and release locks, as well as to wait and pulse threads.

```
class AccountMonitor
{
    private Object thisLock = new Object();
    int balance;
    Random r = new Random();

    public AccountMonitor(int initial)
    {
        balance = initial;
    }

    int Withdraw(int amount)
    {
        Monitor.Enter(thisLock);
        try
        {
            if (balance >= amount)
            {
                Console.WriteLine("Balance before Withdrawal (Monitor) : " + balance);
                Console.WriteLine("Amount to Withdraw : -" + amount);
                balance = balance - amount;
                Console.WriteLine("Balance after Withdrawal : " + balance);
                return amount;
            }
            else
            {
                return 0; // transaction rejected
            }
        }
        finally
        {
            Monitor.Exit(thisLock);
        }
    }

    public void DoTransactions()
    {
        for (int i = 0; i < 100; i++)
        {
            Withdraw(r.Next(1, 100));
        }
    }
}

```
In this example, Monitor.Enter and Monitor.Exit are used to acquire and release the lock, ensuring that only one thread can execute the Withdraw method at a time.

3. Mutex
A Mutex is a synchronization primitive that can be used to manage access to a resource across multiple threads. It can also be used for inter-process synchronization.

```
private static Mutex mutex = new Mutex();

private static void MutexWorker()
{
    mutex.WaitOne(); // Request ownership of the mutex.
    Console.WriteLine("Thread {0} has entered the critical section of Mutex", Thread.CurrentThread.ManagedThreadId);
    Thread.Sleep(1000); // Simulate some work.
    Console.WriteLine("Thread {0} is leaving the critical section of Mutex", Thread.CurrentThread.ManagedThreadId);
    mutex.ReleaseMutex(); // Release the mutex.
}

```

In this example, mutex.WaitOne is used to acquire the mutex, and mutex.ReleaseMutex is used to release it, ensuring that only one thread can enter the critical section at a time.

4. Semaphore
A Semaphore is a synchronization primitive that can be used to control access to a resource pool. It allows a specified number of threads to access the resource concurrently.

```
private static Semaphore _semaphorePool = new Semaphore(0, 3);

private static void SemaphoreWorker(object num)
{
    _semaphorePool.WaitOne();
    Console.WriteLine("Thread {0} enters the semaphore", num);
    Thread.Sleep(1000 + (int)num * 1000);
    Console.WriteLine("Thread {0} releases the semaphore", num);
    _semaphorePool.Release();
}

```

In this example, the semaphore allows up to three threads to enter the critical section concurrently. Additional threads must wait until a slot becomes available.

5. ReaderWriterLockSlim
The ReaderWriterLockSlim class is a synchronization primitive that allows multiple threads to read a resource concurrently, while ensuring exclusive access for write operations.

```
static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
static int resource = 0;
static ManualResetEvent signal = new ManualResetEvent(false);

static void Read()
{
    signal.WaitOne();
    _rw.EnterReadLock();
    try
    {
        Console.WriteLine("reads resource value " + resource);
    }
    finally
    {
        _rw.ExitReadLock();
    }
}

static void Write()
{
    _rw.EnterUpgradeableReadLock();
    try
    {
        Console.WriteLine("reads resource value " + resource);
        _rw.EnterWriteLock();
        try
        {
            resource = 123;
            Console.WriteLine("writes resource value " + resource);
        }
        finally
        {
            _rw.ExitWriteLock();
        }
    }
    finally
    {
        _rw.ExitUpgradeableReadLock();
        signal.Set();
    }
}

```

In this example, ReaderWriterLockSlim allows multiple threads to read the resource concurrently, while ensuring exclusive access for write operations.

## Conclusion
Thread synchronization is essential for ensuring data consistency and preventing race conditions in multi-threaded applications. By using synchronization primitives like lock, Monitor, Mutex, Semaphore, and ReaderWriterLockSlim, you can effectively manage access to shared resources and ensure the correct behavior of your application.
