using System;
using System.Collections.Generic;
using System.Linq;

public enum Vacancy
{
    Manager,
    Clerk,
    Engineer,
    Developer
}

public enum Gender
{
    Male,
    Female,
    Unspecified
}

public interface IEmployee
{
    string ToString();
}

public struct Employee : IEmployee
{
    public string Name;
    public Vacancy Vacancy;
    public DateTime HiringDate;
    public int Salary;
    public Gender Gender;

    public Employee(string name, Vacancy vacancy, DateTime hiringDate, int salary, Gender gender)
    {
        Name = name;
        Vacancy = vacancy;
        HiringDate = hiringDate;
        Salary = salary;
        Gender = gender;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Position: {Vacancy}, Hiring Date: {HiringDate.ToShortDateString()}, Salary: {Salary}, Gender: {Gender}";
    }
}

public class EmployeeManager
{
    private List<Employee> employees;

    public EmployeeManager()
    {
        employees = new List<Employee>();
    }

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public void PrintAllEmployees()
    {
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    public void PrintEmployeesByPosition(Vacancy vacancy)
    {
        foreach (var employee in employees.Where(e => e.Vacancy == vacancy))
        {
            Console.WriteLine(employee.ToString());
        }
    }

    public void PrintManagersWithHigherSalaryThanAverageClerks()
    {
        var averageClerkSalary = employees.Where(e => e.Vacancy == Vacancy.Clerk).Average(e => e.Salary);
        var filteredManagers = employees.Where(e => e.Vacancy == Vacancy.Manager && e.Salary > averageClerkSalary)
                                        .OrderBy(e => e.Name);

        foreach (var manager in filteredManagers)
        {
            Console.WriteLine(manager.ToString());
        }
    }

    public void PrintEmployeesHiredAfterDate(DateTime date)
    {
        var filteredEmployees = employees.Where(e => e.HiringDate > date).OrderBy(e => e.Name);
        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine(employee.ToString());
        }
    }

    public void PrintEmployeesByGender(Gender gender)
    {
        var filteredEmployees = employees.Where(e => e.Gender == gender || gender == Gender.Unspecified);
        foreach (var employee in filteredEmployees)
        {
            Console.WriteLine(employee.ToString());
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        var employeeManager = new EmployeeManager();


        employeeManager.AddEmployee(new Employee("John MacTavish", Vacancy.Manager, new DateTime(2020, 1, 1), 50000, Gender.Male));
        employeeManager.AddEmployee(new Employee("Jane Jackson", Vacancy.Clerk, new DateTime(2019, 5, 10), 30000, Gender.Female));
        employeeManager.AddEmployee(new Employee("Mike Trump", Vacancy.Manager, new DateTime(2020, 1, 1), 50000, Gender.Male));
        employeeManager.AddEmployee(new Employee("George Smith", Vacancy.Clerk, new DateTime(2019, 5, 10), 30000, Gender.Female));
        employeeManager.AddEmployee(new Employee("Alex Mason", Vacancy.Engineer, new DateTime(2018, 3, 15), 70000, Gender.Female));
        employeeManager.AddEmployee(new Employee("Carl Brown", Vacancy.Developer, new DateTime(2021, 6, 20), 80000, Gender.Male));
        employeeManager.AddEmployee(new Employee("Chris Green", Vacancy.Manager, new DateTime(2017, 11, 5), 90000, Gender.Male));
        employeeManager.AddEmployee(new Employee("Diana White", Vacancy.Clerk, new DateTime(2019, 2, 28), 45000, Gender.Female));
        employeeManager.AddEmployee(new Employee("Ethan Black", Vacancy.Engineer, new DateTime(2020, 7, 10), 75000, Gender.Male));
        employeeManager.AddEmployee(new Employee("Fiona Grey", Vacancy.Developer, new DateTime(2021, 1, 22), 85000, Gender.Female));
        employeeManager.AddEmployee(new Employee("George Yellow", Vacancy.Manager, new DateTime(2018, 8, 14), 65000, Gender.Male));
        employeeManager.AddEmployee(new Employee("Hannah Parker", Vacancy.Clerk, new DateTime(2020, 12, 1), 40000, Gender.Female));

        // Displaying all employees
        Console.WriteLine("All Employees:");
        employeeManager.PrintAllEmployees();

        // Displaying employees by a specific position
        Console.WriteLine("\nManagers:");
        employeeManager.PrintEmployeesByPosition(Vacancy.Manager);

        // Displaying managers with higher salary than average clerks
        Console.WriteLine("\nManagers with higher salary than average clerks:");
        employeeManager.PrintManagersWithHigherSalaryThanAverageClerks();

        // Displaying employees hired after a specific date
        Console.WriteLine("\nEmployees hired after 01/01/2020:");
        employeeManager.PrintEmployeesHiredAfterDate(new DateTime(2020, 1, 1));

        // Displaying employees by gender
        Console.WriteLine("\nMale Employees:");
        employeeManager.PrintEmployeesByGender(Gender.Male);

        // Wait for a key press before closing the console window
        Console.ReadKey();
    }
}