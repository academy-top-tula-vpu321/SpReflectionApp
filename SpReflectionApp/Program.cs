using SpReflectionApp;
using System.Reflection;

Type employeeType = typeof(Employee);

ConstructorInfo[] constructors = employeeType.GetConstructors(BindingFlags.Public |
                                                              BindingFlags.NonPublic |
                                                              BindingFlags.Instance);
ConstructorInfo? ctorDefault = null;
ConstructorInfo? ctorParams = null;

foreach (ConstructorInfo ctor in constructors)
{
    

    string modif = "";
    if (ctor.IsPublic)
        modif += "public";
    else if (ctor.IsPrivate)
        modif += "private";
    else if (ctor.IsAssembly)
        modif += "internal";
    else if (ctor.IsFamily)
        modif += "protected";
    else if (ctor.IsFamilyAndAssembly)
        modif += "private protected";
    else if (ctor.IsFamilyOrAssembly)
        modif += "protected internal";

    Console.Write($"{modif} {employeeType.Name}(");
    
    foreach (ParameterInfo param in ctor.GetParameters())
        Console.Write($"{param.ParameterType} {param.Name}, ");

    if (ctor.GetParameters().Length == 0)
        ctorDefault = ctor;
    else
    {
        Console.Write("\b\b");
        ctorParams = ctor;
    }
    Console.WriteLine(")");
        
}


//var employee = ctorDefault?.Invoke(null) as Employee;
var employee = ctorParams?.Invoke(new object[] {"Bobby", 28}) as Employee;

employee?.Work();





