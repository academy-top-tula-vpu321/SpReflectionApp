using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpDynamicLRApp
{
    public class Employee
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public dynamic GetSalary(string format)
        {
            if (format == "string")
                return Salary.ToString();
            else
                return Salary;
        }
    }

    public class EmployeeDynamic : DynamicObject
    {
        Dictionary<string, object> memebers = new();

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            if(value is not null)
            {
                memebers[binder.Name] = value;
                return true;
            }

            return false;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            result = null;
            if(memebers.ContainsKey(binder.Name))
            {
                result = memebers[binder.Name];
                return true;
            }

            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
        {
            result = null;

            if (args?.Length == 0)
            {
                dynamic method = memebers[binder.Name];
                method();
                return true;
            }
            else if (args?[0] is int number)
            {
                dynamic method = memebers[binder.Name];
                result = method(number);
            }

            return result is not null;
        }
    }
}
