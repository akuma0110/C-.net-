namespace testconnectDB.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string DateOfBirth { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(50)]
        public string National { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Qualification { get; set; }

        public int Salary { get; set; }
    }
}
