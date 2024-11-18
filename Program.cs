using System;
using System.Text.RegularExpressions;

public abstract class Employee
{
    private string _nationalCode;
    private string _phoneNumber;

    // Properties
    public string NationalCode
    {
        get => _nationalCode;
        init
        {
            if (Regex.IsMatch(value, @"^\d{10}$")) // National Code must be exactly 10 digits
                _nationalCode = value;
            else
                throw new ArgumentException("Invalid National Code.");
        }
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (Regex.IsMatch(value, @"^\d{10,12}$")) // Phone number validation
                _phoneNumber = value;
            else
                throw new ArgumentException("Invalid Phone Number.");
        }
    }

    public bool IsMarriage { get; set; }
    public double BaseSalary { get; set; }

    // Virtual Method
    public virtual double CalculateSalary(int workingDays, int overtimeHours, double familySalary)
    {
        int workingHours = workingDays * 8; // Assume 8 working hours per day
        double employeeRate = GetEmployeeRate();
        return workingHours * BaseSalary + (IsMarriage ? familySalary : 0) + overtimeHours * BaseSalary * employeeRate;
    }

    protected abstract double GetEmployeeRate(); // Abstract method to get employee rate

    public abstract string DescribeRole(); // Abstract method to describe role

    public override string ToString()
    {
        return $"Name: {FullName}, National Code: {NationalCode}, Base Salary: {BaseSalary}, Married: {IsMarriage}";
    }
}

public class SimpleEmployee : Employee
{
    protected override double GetEmployeeRate() => 1.1;

    public override string DescribeRole() => "Simple Employee: Performs general tasks.";
}

public class ServiceEmployee : Employee
{
    protected override double GetEmployeeRate() => 1.2;

    public override string DescribeRole() => "Service Employee: Handles support and service-related tasks.";
}

public class ManagerEmployee : Employee
{
    protected override double GetEmployeeRate() => 1.5;

    public override string DescribeRole() => "Manager: Oversees and manages team operations.";
}

public class CEOEmployee : Employee
{
    protected override double GetEmployeeRate() => 2.0;

    public override string DescribeRole() => "CEO: Leads the organization and makes executive decisions.";
}

// Test the implementation
class Program
{
    static void Main()
    {
        try
        {
            var employee = new ManagerEmployee
            {
                NationalCode = "1234567890",
                FirstName = "Ali",
                LastName = "Ahmadi",
                PhoneNumber = "09123456789",
                IsMarriage = true,
                BaseSalary = 5000 // In dollars
            };

            Console.WriteLine(employee);
            Console.WriteLine(employee.DescribeRole());
            double salary = employee.CalculateSalary(22, 10, 300); // Example: 22 working days, 10 overtime hours, 300 family salary
            Console.WriteLine($"Calculated Salary: {salary}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
