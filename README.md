
# Employee Management System

This project is a simple implementation of an **Employee Management System** in C#. It demonstrates the use of object-oriented programming (OOP) concepts such as **inheritance**, **abstraction**, **encapsulation**, and **polymorphism**.

## Overview

The `Employee` class serves as the base class for different types of employees in an organization. Each derived class has its unique behavior and employee rate. The system calculates salaries based on working hours, base salary, marriage status, and overtime hours.

### Classes
1. **Employee (Abstract)**
   - Base class for all employee types.
   - Contains common properties like `FirstName`, `LastName`, `NationalCode`, `PhoneNumber`, `BaseSalary`, and `IsMarriage`.
   - Provides methods:
     - `CalculateSalary`: Virtual method for calculating salary.
     - `DescribeRole`: Abstract method to describe the role of an employee.
   - Overrides `ToString` for displaying employee information.

2. **SimpleEmployee**
   - Inherits from `Employee`.
   - Has an employee rate of `1.1`.
   - Performs general tasks.

3. **ServiceEmployee**
   - Inherits from `Employee`.
   - Has an employee rate of `1.2`.
   - Handles support and service-related tasks.

4. **ManagerEmployee**
   - Inherits from `Employee`.
   - Has an employee rate of `1.5`.
   - Oversees and manages team operations.

5. **CEOEmployee**
   - Inherits from `Employee`.
   - Has an employee rate of `2.0`.
   - Leads the organization and makes executive decisions.

## Features

- **Validation:**
  - `NationalCode` must be exactly 10 digits.
  - `PhoneNumber` must be between 10 and 12 digits.
- **Salary Calculation:**
  - Based on the formula:
    ```
    Salary = (WorkingDays * 8 * BaseSalary) + (IsMarriage ? FamilySalary : 0) + (OvertimeHours * BaseSalary * EmployeeRate)
    ```
- **Dynamic Role Description:**
  - Each employee type provides a unique implementation of `DescribeRole`.
- **Encapsulation:**
  - Private fields like `_nationalCode` and `_phoneNumber` ensure controlled access through properties.

## How to Run

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Open the project in Visual Studio or any C# IDE.
3. Build the solution to restore dependencies.
4. Run the program.

## Example Usage

The following code snippet shows how to use the `ManagerEmployee` class:

```csharp
var employee = new ManagerEmployee
{
    NationalCode = "1234567890",
    FirstName = "Ali",
    LastName = "Ahmadi",
    PhoneNumber = "09123456789",
    IsMarriage = true,
    BaseSalary = 5000 // In dollars
};

Console.WriteLine(employee); // Prints employee details
Console.WriteLine(employee.DescribeRole()); // Prints role description

double salary = employee.CalculateSalary(22, 10, 300); 
Console.WriteLine($"Calculated Salary: {salary}"); // Prints calculated salary
```

## Output Example

```plaintext
Name: Ali Ahmadi, National Code: 1234567890, Base Salary: 5000, Married: True
Manager: Oversees and manages team operations.
Calculated Salary: 94000
```

## Project Structure

```
EmployeeManagementSystem/
├── Program.cs      # Entry point of the application
├── Employee.cs     # Abstract base class
├── SimpleEmployee.cs
├── ServiceEmployee.cs
├── ManagerEmployee.cs
├── CEOEmployee.cs
├── README.md       # Project documentation
```

## Requirements

- .NET SDK (version 5.0 or later)
- C# Compiler

## License

This project is licensed under the MIT License. Feel free to use and modify it as needed.

## Contact

For any inquiries or contributions, please reach out to:
- **Name:** Reza Noel
- **Email:** rezatavangar112@gmail.com
