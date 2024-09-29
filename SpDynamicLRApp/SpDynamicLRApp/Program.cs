using SpDynamicLRApp;
using System.Dynamic;
using System.Threading.Channels;

object obj = 25;

obj = "Hello world";
obj = 10.5;
obj = new List<string>();

obj = 10;
// obj += 5;

dynamic dyn = 10;
dyn = "Hello world";
dyn = 10;
dyn += 5;

dynamic user = new ExpandoObject();

user.Name = "Bobby";
user.Age = 25;
user.Cities = new List<string>() { "Moscow", "Tula", "Orel" };

user.Info = (Action)(() =>
{
    Console.Write($"User name: {user.Name}, age: {user.Age}, cities: ");
    foreach (var c in user.Cities)
        Console.Write($"{c} ");
    Console.WriteLine();
});

user.Info();


dynamic person = new EmployeeDynamic();
person.Name = "Tommy";
person.Age = 30;
person.AgeAdd = (Func<int, int>)((int diff) => person.Age += diff);
person.Info = (Action)(() => Console.WriteLine($"Name: {person.Name}, Age: {person.Age}"));

person.Info();
person.AgeAdd(5);
person.Info();



