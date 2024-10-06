List<Task<int>> tasks = new();

for(int i = 1000; i < 1010; i++)
{
    tasks.Add(GaussAmount(i));
}

//await Task.WhenAll(tasks);
//foreach(var task in tasks)
//    Console.WriteLine(task.Result);

int[] results = await Task.WhenAll(tasks);
foreach(var result in results)
    Console.WriteLine(result);



async Task<int> GaussAmount(int n)
{
    int result = 0;
    for (int i = 1; i <= n; i++)
        result += i;

    Random random = new Random();
    int duration = random.Next(2000, 5000);
    await Task.Delay(duration);

    return result;
}