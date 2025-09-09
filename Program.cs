/*
Write a program to create a list of employees. Consider a hard coded list. 
Display all employees who have salary more than $5000 and age < 30.
*/

using System.Xml.Linq;

namespace Assignment_10._2._2
{
    public class Employee(string Name, int Age, int Salary)
    {
        public string Name { get; set; } = Name;
        public int Age { get; set; } = Age;
        public int Salary { get; set; } = Salary;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Hardcode list of employees with name, age and salary
            List<Employee> employees = new()
            {
                new Employee("Tim Apple",64,74600000),
                new Employee("Billy Windows",69,700000000),
                new Employee("Linus Linux",55,1550000),
                new Employee("Mark Meta",41,27220000),
                new Employee("Emily Davis",24,8000),
                new Employee("Isabella Martinez",25,9000),
                new Employee("Frank Miller",50,10200)
            };

            // Get list of employees with salary >$5k and age < 30
            var employeeList = from employee in employees
                          where employee.Salary > 5000 && employee.Age < 30
                          select (employee.Name, employee.Age, employee.Salary);

            // Get length of the longest employee name            
            int nameLength = (from employee in employees
                              orderby employee.Name.Length descending
                              select employee.Name).First().Length;

            // Get length of the largest employee salary
            int salaryMaxLength = (from employee in employees
                             orderby employee.Salary descending
                             select employee.Salary).First().ToString("C0").Length;

            // Print all employees (with some extra formatting fun)
            Console.WriteLine("All employees:");
            string header = $"  {"Name".PadRight(nameLength)} | Age | {"Salary".PadLeft(salaryMaxLength)}";
            Console.WriteLine(header);
            Console.WriteLine($"  {new string('-', nameLength)}-+-----+-{new string('-',salaryMaxLength)}");
            foreach(var employee in employees)
            {
                Console.WriteLine($"  {employee.Name.PadRight(nameLength)} |  {employee.Age} | {employee.Salary.ToString("C0").PadLeft(salaryMaxLength)}");
            }

            // Print employees with salary > $5000 and age < 30
            Console.WriteLine("\nEmployees with Salary > $5000 and Age < 30:");
            Console.WriteLine(header);
            Console.WriteLine($"  {new string('-', nameLength)}-+-----+-{new string('-', salaryMaxLength)}");
            foreach (var employee in employeeList)
            {
                Console.WriteLine($"  {employee.Name.PadRight(nameLength)} |  {employee.Age} | {employee.Salary.ToString("C0").PadLeft(salaryMaxLength)}");
            }
        }
    }
}
