using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTapLinQ
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public DateTime Birthday { get; set; }

        public int DepartmentID { get; set; }
        public static List<Employee> getEmployee()
        {
            return new List<Employee>
            {
                new Employee { ID = 1, Name = "A", Age = 22, Salary = 2000, Birthday = DateTime.Parse("21/02/2002"), DepartmentID = 1},
                new Employee { ID = 2, Name = "B", Age = 25, Salary = 2500, Birthday = DateTime.Parse("22/08/1999"), DepartmentID = 2},
                new Employee { ID = 3, Name = "C", Age = 23, Salary = 2000, Birthday = DateTime.Parse("11/09/2001"), DepartmentID = 3 },
                new Employee { ID = 4, Name = "D", Age = 40, Salary = 4000, Birthday = DateTime.Parse("10/12/1984"), DepartmentID = 1},
                new Employee { ID = 5, Name = "E", Age = 33, Salary = 3200, Birthday = DateTime.Parse("05/09/1991"), DepartmentID = 2}
            };
        }

        public int CalculateAge(DateTime BirthDay)
        {
            DateTime Today = DateTime.Now;
            return Today.Year - Birthday.Year;
        }
    }
}