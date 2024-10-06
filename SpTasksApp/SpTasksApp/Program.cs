CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
CancellationToken cancellationToken = cancellationTokenSource.Token;

Task task = new Task(() => PrintNumbers(cancellationToken)
//() =>
//{
//    int i = 0;

//    cancellationToken.Register(() =>
//    {
//        Console.WriteLine("Task canceled!");
//        i = 10;
//    });
//    for(; i < 10; i++)
//    {
//        Console.WriteLine($"current {i}");
//        Thread.Sleep(300);
//    }
//}
, cancellationToken);
task.Start();

Thread.Sleep(2000);

cancellationTokenSource.Cancel();

Thread.Sleep(1000);

Console.WriteLine($"Task status: {task.Status}");
cancellationTokenSource.Dispose();


void PrintNumbers(CancellationToken token)
{
    for(int i = 0; i < 10; i++)
    {
        if (token.IsCancellationRequested)
            return;
        Console.WriteLine($"current {i}");
        Thread.Sleep(300);
    }
}
