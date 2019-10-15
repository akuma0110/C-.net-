using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testconnectDB.Models
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees()
        {
            EmployeeDBContext employeeDBContext = new EmployeeDBContext();
            return employeeDBContext.Employees.ToList();
        }
    }
}