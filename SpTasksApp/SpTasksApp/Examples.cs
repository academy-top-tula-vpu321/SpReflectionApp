using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpTasksApp
{
    static class Examples
    {
        public static void TaskWelcome()
        {
            Task task1 = new(() => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Hello world"));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Hello world"));

            Task task3 = Task.Run(() => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Hello world"));

            task1.Wait();
            task2.Wait();
            task3.Wait();

        }

        public static void TaskOuterInner()
        {
            Task outerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Outer task starting...");

                Task innerTask = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Inner task starting...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task finished...");
                }, TaskCreationOptions.AttachedToParent);

                Console.WriteLine("Outer task finished...");
            });

            outerTask.Wait();
            Console.WriteLine("Main finished");
        }

        public static void TasksWaiting()
        {
            Task[] tasks = new Task[5];

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Console.WriteLine($"Task {i} strting...");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Task {i} finished...");
                });
                tasks[i].Start();
            }

            //Task.WaitAll(tasks);
            //for (int i = 0; i < tasks.Length; i++)
            //    tasks[i].Wait();

            Task.WaitAny(tasks);
        }

        public static void TaskContinues()
        {
            //Task<int> amountTask = new(() => GaussAmount(1000));
            //amountTask.Start();

            //int resultTask = amountTask.Result;
            //Console.WriteLine($"Result = {resultTask}");

            Task<int> paramsTask = new(() => DoubleAmount(1000, 1000));
            Task<int> resultTask = paramsTask.ContinueWith(task => GaussAmount(task.Result));
            Task printTask = resultTask.ContinueWith(task => PrintResult(task.Result));

            paramsTask.Start();
            printTask.Wait();

            void PrintResult(int result)
            {
                Console.WriteLine($"Result = {result}");
            }

            int GaussAmount(int number)
            {
                int result = 0;
                for (int i = 1; i <= number; i++)
                    result += i;
                return result;
            }

            int DoubleAmount(int a, int b)
            {
                return a + b;
            }
        }

        public static void ParallelExample()
        {
            //Parallel.Invoke(
            //    Amount,
            //    PrintInfo,
            //    Amount,
            //    () =>
            //    {
            //        Console.WriteLine("Hello world");
            //    }
            //    );

            Parallel.For(1000, 1010, AmountNumber);



            int GaussAmount(int number)
            {
                int result = 0;
                for (int i = 1; i <= number; i++)
                    result += i;
                return result;
            }

            void Amount()
            {
                int result = 0;
                for (int i = 1; i <= 1000; i++)
                    result += i;
                Console.WriteLine($"Task {Task.CurrentId} ranning = {result}");
            }

            void AmountNumber(int number)
            {
                int result = 0;
                for (int i = 1; i <= number; i++)
                    result += i;
                Console.WriteLine($"Task {Task.CurrentId} ranning = {result}");
            }


            void PrintInfo()
            {
                Console.WriteLine($"Task {Task.CurrentId} ranning");
            }
        }

        public static void TaskCanceledProperty()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task task = new Task(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        Console.WriteLine("Task canceled");

                        // soft cancel
                        //return;

                        // exception cancel
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    Console.WriteLine($"current {i}");
                    Thread.Sleep(500);
                }
            }, cancellationToken);


            try
            {
                task.Start();

                Thread.Sleep(2000);

                cancellationTokenSource.Cancel();

                //Thread.Sleep(1000);
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.Message);
            }



            Console.WriteLine($"Task status: {task.Status}");
            cancellationTokenSource.Dispose();

        }
    }
}
