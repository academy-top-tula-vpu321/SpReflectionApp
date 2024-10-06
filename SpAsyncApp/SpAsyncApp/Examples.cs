using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpAsyncApp
{
    internal class Examples
    {
        public static async Task WelcomeAsync()
        {
            await PrintAsync();
            Console.WriteLine("Good by world");

            void Print()
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello world");
            }

            async Task PrintAsync()
            {
                Console.WriteLine("Async start");
                await Task.Run(() => Print());
                Console.WriteLine("Async finish");
            }
        }

        public static async Task ExecutionAsync()
        {
            var taskBobby = PrintEmployeeAsync("Bobby");
            var taskSammy = PrintEmployeeAsync("Sammy");
            var taskTommy = PrintEmployeeAsync("Tommy");

            await taskBobby;
            await taskSammy;
            await taskTommy;

            Func<string, Task> printEmployeeLambdaAsync = async (name) =>
            {
                await Task.Delay(2000);
                Console.WriteLine($"Good by {name}");
            };

            var taskKenny = printEmployeeLambdaAsync("Kenny");
            var taskLenny = printEmployeeLambdaAsync("Lenny");
            var taskJenny = printEmployeeLambdaAsync("Jenny");

            await taskKenny;
            await taskLenny;
            await taskJenny;

            async Task PrintEmployeeAsync(string employee)
            {
                await Task.Delay(3000);
                Console.WriteLine($"Hello {employee}");
            }


        }

        public static async Task ReturnValueAsync()
        {
            //var task1 = GaussAmount(2000);
            //var task2 = GaussAmount(2000);

            //int res1 = await task1;
            //int res2 = await task2;

            //Console.WriteLine(res1);
            //Console.WriteLine(res2);

            Console.WriteLine(GaussAmountValue(2000));
            Console.WriteLine(GaussAmountValue(2000));

            async Task<int> GaussAmount(int n)
            {
                int result = 0;
                for (int i = 1; i <= n; i++)
                    result += i;

                await Task.Delay(3000);

                return result;
            }

            ValueTask<int> GaussAmountValue(int n)
            {
                int result = 0;
                for (int i = 1; i <= n; i++)
                    result += i;

                Task.Delay(3000);

                return new ValueTask<int>(result);
            }
        }
    }
}
