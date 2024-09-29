using SpReflectionApp;
using System.Reflection;

//Type employeeType = typeof(Employee);

//MethodInfo[] methods = employeeType.GetMethods();

//foreach (MethodInfo method in methods)
//    Console.WriteLine(method.Name);


Assembly unitsAsm = Assembly.LoadFrom("Units.dll");
Console.WriteLine($"Assembly {unitsAsm.FullName} loading");

Type[] types = unitsAsm.GetTypes();
foreach (Type type in types)
    Console.WriteLine($"Type {type.Name}");






