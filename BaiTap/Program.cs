using System;
namespace BaiTapLinQ
{
    public class Run
    {
        public static void Main(string[] args)
        {
            //Cau2a
            //Max Salary
            var maxSalary = Employee.getEmployee().Max(x => x.Salary);
            Console.WriteLine("Max salary is: " + maxSalary);

            //Min Salary
            var minSalary = Employee.getEmployee().Min(x => x.Salary);
            Console.WriteLine("Min salary is: " + minSalary);

            //Average Salary
            var averageSalary = Employee.getEmployee().Average(x => x.Salary);
            Console.WriteLine("Average salary is: " + averageSalary);
            //End 2a

            //Cau 2b
            //GroupJoin
            Console.WriteLine("\n\nGroupJoin");
            var groupJoin = Department.getDepartments()
                                      .GroupJoin(Employee.getEmployee(),
                                      d => d.ID, e => e.DepartmentID,
                                      (department, employee) => new
                                      {
                                          Department = department,
                                          Employee = employee
                                      });
            foreach (var department in groupJoin)
            {
                Console.WriteLine("Department: " + department.Department.Name);
                foreach (var employee in department.Employee)
                {
                    Console.WriteLine("EmployeeID: " + employee.ID + ", EmployeeName: " + employee.Name);
                }
                Console.WriteLine();
            }

            //LeftJoin
            Console.WriteLine("\n\nLeft join");
            var leftJoin = from e in Employee.getEmployee()
                                join d in Department.getDepartments()
                                on e.DepartmentID equals d.ID into eGroup
                                from d in eGroup.DefaultIfEmpty()
                                select new
                                {
                                    EmployeeName = e.Name,
                                    DepartmentName = d == null ? "No Department" : d.Name
                                };
            foreach(var employee in leftJoin)
            {
                Console.WriteLine(employee.EmployeeName + "-" + employee.DepartmentName);
            }

            //RightJoin
            Console.WriteLine("\n\nRight join");
            var rightJoin = from d in Department.getDepartments()
                                join e in Employee.getEmployee()
                                on d.ID equals e.DepartmentID into eGroup
                                from e in eGroup.DefaultIfEmpty()
                                select new
                                {
                                    DepartmentName = d.Name,
                                    EmployeeName = e == null ? "No employees" : e.Name
                                };
            foreach (var department in rightJoin)
            {
                Console.WriteLine(department.DepartmentName + "-" + department.EmployeeName);
            }
            //End 2b

            //Cau 2c
            //Max age
            Console.WriteLine("\n\n");
            var maxAge = Employee.getEmployee().Max(e => e.CalculateAge(e.Birthday));
            Console.WriteLine("Max age: " + maxAge);

            var minAge = Employee.getEmployee().Min(e => e.CalculateAge(e.Birthday));
            Console.WriteLine("Min age: " + minAge);
        }
    }
}