using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpThreadsApp
{
    static class Examples
    {
        static public void ThreadWelcome()
        {
            Thread threadCurrent = Thread.CurrentThread;

            Console.WriteLine($"Name: {threadCurrent.Name}");
            threadCurrent.Name = "Main";
            Console.WriteLine($"Name: {threadCurrent.Name}");

            Console.WriteLine($"Is Alive?: {threadCurrent.IsAlive}");
            Console.WriteLine($"Id: {threadCurrent.ManagedThreadId}");
            Console.WriteLine($"Priority: {threadCurrent.Priority}");
            Console.WriteLine($"Status: {threadCurrent.ThreadState}");

            //Thread threadTwo = new(ActionMethod);
            //Thread threadTwo = new(new ThreadStart(ActionMethod));
            Thread threadTwo = new(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}: {i}");
                    Thread.Sleep(1000);
                }
            });
            Thread threadThree = new(new ParameterizedThreadStart(ParamLoop));
            threadThree.Start(15);

            threadTwo.Start();
            ActionMethod();


            void ActionMethod()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}: {i}");
                    Thread.Sleep(1000);
                }
            }

            void ParamLoop(object? size)
            {
                if (size is int sizeLoop)
                    for (int i = 0; i < sizeLoop; i++)
                    {
                        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}: {i}");
                        Thread.Sleep(1000);
                    }
            }
        }
    }
}
