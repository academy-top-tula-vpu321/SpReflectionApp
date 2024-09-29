using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpReflectionApp
{
    static class Examples
    {
        public static void GetTypesInfo()
        {
            int number = 100;

            Type? type = typeof(Employee); //Type.GetType("employee", false, true); // typeof(Int32); //number.GetType();
            if (type is not null)
            {
                Console.WriteLine(type.Name);
                Console.WriteLine(type.Assembly);
                Console.WriteLine(type.Namespace);
                Console.WriteLine(type.IsClass);
                Console.WriteLine(type.IsValueType);

                Console.WriteLine("\nInterfaces:");
                foreach (var inter in type.GetInterfaces())
                    Console.WriteLine(inter.Name);

            }
        }

        public static void GetMembersInfo()
        {
            Type employeeType = typeof(Employee);

            foreach (MemberInfo member in employeeType.GetMembers(BindingFlags.Public |
                                                                 BindingFlags.NonPublic |
                                                                 BindingFlags.Instance |
                                                                 BindingFlags.DeclaredOnly))
                Console.WriteLine($"{member.DeclaringType}\t{member.MemberType}\t{member.Name}");
            Console.WriteLine();


            MemberInfo[] nameProp = employeeType.GetMember("Name");
            foreach (MemberInfo member in nameProp)
                Console.WriteLine($"{member.DeclaringType}\t{member.MemberType}\t{member.Name}");
        }

        public static void GetConstructors()
        {
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
            var employee = ctorParams?.Invoke(new object[] { "Bobby", 28 }) as Employee;

            employee?.Work();
        }
    }
}
