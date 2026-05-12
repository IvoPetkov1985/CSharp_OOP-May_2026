using System.Text;

namespace _01.CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new();

            int employeesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < employeesCount; i++)
            {
                string[] employeeData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string employeeName = employeeData[0];
                decimal salary = decimal.Parse(employeeData[1]);
                string departmentName = employeeData[2];
                Employee employee = new(employeeName, salary);
                Department department = departments.FirstOrDefault(d => d.Name == departmentName);

                if (department == null)
                {
                    department = new(departmentName);
                    departments.Add(department);
                }

                department.AddEmployee(employee);
            }

            decimal bestAverageSalary = 0;
            Department bestDepartment = null;

            foreach (Department department in departments)
            {
                decimal currentSalary = department.GetAverageSalary();

                if (currentSalary > bestAverageSalary)
                {
                    bestDepartment = department;
                    bestAverageSalary = currentSalary;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDepartment.Name}");
            Console.WriteLine(bestDepartment.ToString());
        }
    }

    public class Employee
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"{Name} {Salary:F2}";
        }
    }

    public class Department
    {
        public Department(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public string Name { get; set; }

        public List<Employee> Employees { get; set; }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public decimal GetAverageSalary()
        {
            return Employees.Average(d => d.Salary);
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            foreach (Employee emp in Employees.OrderByDescending(e => e.Salary))
            {
                builder.AppendLine(emp.ToString());
            }

            return builder.ToString().TrimEnd();
        }
    }
}
