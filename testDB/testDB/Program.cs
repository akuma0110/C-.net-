using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testDB
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDBEntities entity = new EmployeeDBEntities();
            foreach(Employee e in entity.Employees)
            {
                Console.WriteLine("Name:{0}, Gender:{}");
            }
        }
    }
}
