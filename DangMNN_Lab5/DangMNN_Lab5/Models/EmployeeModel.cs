using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DangMNN_Lab5.Models
{
    public class EmployeeModel : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public class Employee
    {
        [Key, Display(Name ="ID")]
        public int empID { get; set; }
        [Required, StringLength(40), Display(Name ="Name")]
        public string empName { get; set; }
        [Required, StringLength(40), Display(Name = "Date of birth")]
        public string empDob { get; set; }
        [Required, StringLength(40), Display(Name = "Address")]
        public string empAddress { get; set; }
        [Required, Display(Name = "Years of Experience")]
        public int empYoE { get; set; }
        [Required, StringLength(40), Display(Name = "Phone")]
        public string empPhone { get; set; }
        [Required, StringLength(40), Display(Name = "Email")]
        public string empEmail { get; set; }
        [Required, StringLength(40), Display(Name = "Date of joining")]
        public string emoDoJ { get; set; }
    }

}