using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public decimal Salary { get; set; }
        public decimal Premium { get; set; }
        public int DepartmentId { get; set; }
        public int GroupId { get; set; }
    }
}
