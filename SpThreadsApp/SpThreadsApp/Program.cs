//int count = 0;

//object locker = new();
//Mutex mutex = new();
//AutoResetEvent handler = new(true);

//for(int i = 0; i < 5; i++)
//{
//    Thread thread = new(Increment);
//    thread.Start();
//}

for(int i = 0; i < 10; i++)
{
    Car car = new();
}




//void Increment()
//{
//    for (int i = 0; i < 10; i++)
//    {
//        //lock (locker)
//        //mutex.WaitOne();
//        handler.WaitOne();
//        count++;
//        handler.Set();
//        //mutex.ReleaseMutex();
        

//        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {count}");
//        Thread.Sleep(100);
//    }

//    //bool lockTaken = false;
//    //try
//    //{
//    //    Monitor.Enter(locker, ref lockTaken);
//    //    for (int i = 0; i < 10; i++)
//    //    {
//    //        //lock (locker)

//    //        count++;
//    //        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {count}");
//    //        Thread.Sleep(100);
//    //    }
//    //}
//    //finally
//    //{
//    //    if (lockTaken) Monitor.Exit(locker);
//    //}
//}

class Car
{
    static int globalId = 0;
    static Semaphore semaphore = new(5, 5);

    Thread thread;
    int count = 10;

    public Car()
    {
        thread = new Thread(Parking);
        thread.Name = $"Car {++globalId}";
        thread.Start();
        count = 10;
    }

    public void Parking()
    {
        while(this.count > 0)
        {
            semaphore.WaitOne();

            Console.WriteLine($"{Thread.CurrentThread.Name} to parking...");
            Thread.Sleep(500);
            Console.WriteLine($"{Thread.CurrentThread.Name} out from parking...");
            this.count--;

            semaphore.Release();
            Thread.Sleep(500);
        }
        
    }

}