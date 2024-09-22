using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpReflectionApp
{
    public class Employee : IStuddable, IWorkable
    {
        string? name;
        int age;
        public string? Name
        {
            set => name = value;
            get => name;
        }
        public int Age
        {
            set => age = value;
            get => age;
        }
        internal Employee()
        {
            name = "Anonim";
            age = 0;
        }

        public Employee(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Study()
        {
            Console.WriteLine($"{Name} studying");
        }

        public void Work()
        {
            Console.WriteLine($"{Name} working");
        }
    }

    interface IStuddable
    {
        void Study();
    }

    interface IWorkable
    {
        void Work();
    }
}
