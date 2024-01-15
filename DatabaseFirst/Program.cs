
using DatabaseFirst.Context;
using DatabaseFirst.Enums;
using DatabaseFirst.Models;
using DatabaseFirst.Repositories;
using DatabaseFirst.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var servicesCollection = new ServiceCollection();
var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
var configuration = builder.Build();

//Service Registrations & DBContext Registrations
servicesCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
servicesCollection.AddScoped<IEmployeeService, EmployeeService>();
servicesCollection.AddDbContext<EmpDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("localConnection")));

//Creating Service Provider Instance to invoke service methods of EmployeeService
ServiceProvider serviceProvider = servicesCollection.BuildServiceProvider();
var employeeService = serviceProvider.GetService<IEmployeeService>();

if (employeeService is not null)
{
    #region [ Get All Employees Record ]
    Console.WriteLine("======================================= Get All Employees Record ===================================");
    Console.WriteLine();
    employeeService.GetEmployees();
    Console.WriteLine();
    #endregion

    #region [ Get Employee By ID ]
    Console.WriteLine("========================================== Get Employee By ID ======================================");
    Console.WriteLine();
    employeeService.GetEmployeeById(2);
    Console.WriteLine();
    #endregion

    #region [ Adding new employee record ]
    Console.WriteLine("===================================== Adding new employee record ===================================");
    var newEmployee = new EmployeeDto()
    {
        Firstname = "Jacob",
        Lastname = "Smith",
        Address = "1069 Echo Lane, MI",
        City = "Miami",
        Email = "jacob.smith@deloitte.com",
        DesgId = (int)Designation.HumanResource
    };
    var id = employeeService.AddNewEmployee(newEmployee);
    Console.WriteLine();
    #endregion

    #region [ Update Employee record By ID ]
    Console.WriteLine("=================================== Update Employee record By ID ===================================");
    employeeService.UpdateEmployee(id);
    Console.WriteLine();
    #endregion

    #region [ Delete Employee record By ID ]
    Console.WriteLine("=================================== Delete Employee record By ID ===================================");
    employeeService.DeleteEmployee(id);
    Console.WriteLine();
    #endregion

    #region [ Get All Employees by skipping 2 records ]
    Console.WriteLine("============================= Get All Employees by skipping 2 records ==============================");
    Console.WriteLine();
    employeeService.GetEmployeesBySkipping(true);
    Console.WriteLine();
    #endregion

    #region [ Get All Employees by taking 4 records ]
    Console.WriteLine("============================= Get All Employees by taking 4 records ================================");
    Console.WriteLine();
    employeeService.GetEmployeesByTaking(true);
    Console.WriteLine();
    #endregion

    #region [ Get All Employees order by FirstName ]
    Console.WriteLine("============================== Get All Employees order by FirstName ================================");
    Console.WriteLine();
    employeeService.GetEmployeesOrderByName(true);
    Console.WriteLine();
    #endregion

    #region [ Get All Employees order by FirstName Descending ]
    Console.WriteLine("========================= Get All Employees order by FirstName Descending ==========================");
    Console.WriteLine();
    employeeService.GetEmployeesOrderByNameDesc(true);
    Console.WriteLine();
    #endregion

    #region [ Get All Employees Group By 'City' ]
    Console.WriteLine("=============================== Get All Employees Group By 'City' ==================================");
    Console.WriteLine();
    employeeService.GetEmployeesGroupBy(true);
    Console.WriteLine();
    #endregion

    #region [ Get all details of Employees using JOIN ]
    Console.WriteLine("============================= Get all details of Employees using JOIN ===============================");
    Console.WriteLine();
    employeeService.GetFullDataOfEmployees(true);
    Console.WriteLine();
    #endregion

    Console.ReadLine();
}

