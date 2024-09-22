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
    }
}
