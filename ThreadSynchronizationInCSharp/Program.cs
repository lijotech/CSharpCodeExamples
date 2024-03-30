class Program
{
    private static Mutex mutex = new Mutex();
    // Create a semaphore that can satisfy up to three concurrent requests.
    private static Semaphore _semaphorePool = new Semaphore(0, 3);

    static ReaderWriterLockSlim _rw = new ReaderWriterLockSlim();
    static int resource = 0;
    //This is added to ensure that write operation finishes before read
    static ManualResetEvent signal = new ManualResetEvent(false);

    static void Main(string[] args)
    {
        // Create new instances of Account for lock and Monitor examples
        AccountLock accountLock = new AccountLock(1000);
        AccountMonitor accountMonitor = new AccountMonitor(1000);

        #region Lock
        // Start the threads for lock example
        Thread[] threadsLock = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            Thread t = new Thread(new ThreadStart(accountLock.DoTransactions));
            threadsLock[i] = t;
        }
        for (int i = 0; i < 10; i++)
        {
            threadsLock[i].Start();
        }
        #endregion

        #region Monitor
        // Start the threads for Monitor example
        Thread[] threadsMonitor = new Thread[10];
        for (int i = 0; i < 10; i++)
        {
            Thread t = new Thread(new ThreadStart(accountMonitor.DoTransactions));
            threadsMonitor[i] = t;
        }
        for (int i = 0; i < 10; i++)
        {
            threadsMonitor[i].Start();
        }
        #endregion

        #region Mutex
        //Start the threads for Mutex
        for (int i = 0; i < 4; i++)
        {
            Thread newThread = new Thread(new ThreadStart(MutexWorker));
            newThread.Start();
        }
        #endregion

        #region ReaderWriterLockSlim
        // Start a new thread that will write the data and read it after writing.
        Thread t1 = new Thread(new ThreadStart(Write));
        t1.Start();
        // Start a new thread that will read the data.
        Thread t2 = new Thread(new ThreadStart(Read));
        t2.Start();
        // Wait for the two threads to finish.
        t1.Join();
        t2.Join();
        #endregion


        #region Semaphore
        // Create and start five numbered threads for Semaphore example.
        for (int i = 0; i < 5; i++)
        {
            Thread t = new Thread(new ParameterizedThreadStart(SemaphoreWorker));
            t.Start(i);
        }
        Thread.Sleep(500);
        Console.WriteLine("Main thread calls Release(3) Semaphore.");
        _semaphorePool.Release(3);
        Console.WriteLine("Main thread exits.");
        #endregion

    }

    static void Read()
    {
        // Wait until Write method signals
        signal.WaitOne();
        // Enter read lock
        _rw.EnterReadLock();
        try
        {
            // (It's safe for this thread to read from sharedResource)
            Console.WriteLine("reads resource value " + resource);
        }
        finally
        {
            // Ensure that the lock is released.
            _rw.ExitReadLock();
        }
    }

    static void Write()
    {
        // Enter upgradeable lock
        _rw.EnterUpgradeableReadLock();
        try
        {
            // It's safe for this thread to read from sharedResource
            Console.WriteLine("reads resource value " + resource);
            // Enter write lock
            _rw.EnterWriteLock();
            try
            {
                // It's safe for this thread to write to sharedResource
                resource = 123;
                Console.WriteLine("writes resource value " + resource);
            }
            finally
            {
                // Ensure that the lock is released.
                _rw.ExitWriteLock();
            }
        }
        finally
        {
            // Ensure that the lock is released.
            _rw.ExitUpgradeableReadLock();
            // Signal the Read method to proceed
            signal.Set();
        }
    }

    private static void SemaphoreWorker(object num)
    {
        _semaphorePool.WaitOne();
        Console.WriteLine("Thread {0} enters the semaphore", num);
        Thread.Sleep(1000 + (int)num * 1000);
        Console.WriteLine("Thread {0} releases the semaphore", num);
        _semaphorePool.Release();
    }

    private static void MutexWorker()
    {
        mutex.WaitOne(); // Request ownership of the mutex.
        Console.WriteLine("Thread {0} has entered the critical section of Mutex", Thread.CurrentThread.ManagedThreadId);
        Thread.Sleep(1000); // Simulate some work.
        Console.WriteLine("Thread {0} is leaving the critical section of Mutex", Thread.CurrentThread.ManagedThreadId);
        mutex.ReleaseMutex(); // Release the mutex.
    }
}

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
        // This condition will never be true unless the lock statement
        // is commented out:
        if (balance < 0)
        {
            throw new Exception("Negative Balance");
        }
        // Comment out the next line to see the effect of leaving out 
        // the lock keyword:
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
            if (balance < 0)
            {
                throw new Exception("Negative Balance");
            }
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
