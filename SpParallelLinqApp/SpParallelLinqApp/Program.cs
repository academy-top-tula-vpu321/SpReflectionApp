Random random = new();
List<int> array = new();

for (int i = 0; i < 20; i++)
    array.Add(i + 1);

var squares = from item in array.AsParallel()
                                .AsOrdered()
              where item % 2 == 0  
              //orderby item
              select Square(item);

//array.AsParallel()
//     .Select(item => Square(item))
//     .ForAll(Console.WriteLine);

foreach (var square in squares)
    Console.WriteLine(square);

int Square(int x) => x * x;