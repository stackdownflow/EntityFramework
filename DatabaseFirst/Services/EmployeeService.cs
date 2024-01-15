using ConsoleTables;
using DatabaseFirst.Models;
using DatabaseFirst.Repositories;

namespace DatabaseFirst.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public int AddNewEmployee(EmployeeDto employee)
        {
           var newEmployeeId = _employeeRepository.AddNewEmployee(employee);

            Console.WriteLine();
            Console.WriteLine("New record inserted successfully");
            Console.WriteLine();

            //Fetching all the record after insert done.
            GetEmployees();

            return newEmployeeId;
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeeRepository.DeleteEmployee(employeeId);

            Console.WriteLine();
            Console.WriteLine("Record deleted successfully");
            Console.WriteLine();

            //Fetching all the record after insert done.
            GetEmployees();
        }

        public void GetEmployeeById(int employeeId)
        {
            var result = _employeeRepository.GetEmployeeById(employeeId);
            if (result == null)
                Console.WriteLine("No record found with employee Id : {0}", employeeId);
            else
                DisplayDataInTableFormat(result);
        }

        public void GetEmployees(bool isLambdaQuery = false)
        {
            var result = _employeeRepository.GetEmployees();
            DisplayDataInTableFormat(result);
        }

        public void UpdateEmployee(int employeeId)
        {
            _employeeRepository.UpdateEmployee(employeeId);

            Console.WriteLine();
            Console.WriteLine("New record updated successfully");
            Console.WriteLine();

            //Fetching all the record after insert done.
            GetEmployees();
        }        

        public void GetEmployeesBySkipping(bool isLambdaQuery = false)
        {
            var result = _employeeRepository.GetEmployeesBySkipping();
            DisplayDataInTableFormat(result);
        }

        public void GetEmployeesByTaking(bool isLambdaQuery = false)
        {
            var result = _employeeRepository.GetEmployeesByTaking();
            DisplayDataInTableFormat(result);
        }

        public void GetEmployeesOrderByName(bool isLambdaQuery = false)
        {
            var result = _employeeRepository.GetEmployeesOrderByName();
            DisplayDataInTableFormat(result);
        }

        public void GetEmployeesOrderByNameDesc(bool isLambdaQuery = false)
        {
            var result = _employeeRepository.GetEmployeesOrderByNameDesc();
            DisplayDataInTableFormat(result);
        }

        public void GetEmployeesGroupBy(bool isLambdaQuery = false)
        {
            var result = _employeeRepository.GetEmployeesGroupBy();
            DisplayDataFormatForGroupBy(result);
        }

        public void GetFullDataOfEmployees(bool isLambdaQuery = false)
        {
            var result = _employeeRepository.GetFullDataOfEmployees();
            DisplayFullDataInTableFormat(result);
        }

        private void DisplayDataInTableFormat(List<EmployeeDto> employeeList)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", "First Name", "Last Name", "Address", "City", "Email" },
                EnableCount = false
            });

            foreach (var employee in employeeList)
            {
                table.AddRow(
                    employee.Id,
                    employee.Firstname,
                    employee.Lastname,
                    employee.Address,
                    employee.City,
                    employee.Email
                    );
            }

            table.Write();
        }

        private void DisplayDataInTableFormat(EmployeeDto employee)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", "First Name", "Last Name", "Address", "City", "Email" },
                EnableCount = false
            });

            table.AddRow(employee.Id, employee.Firstname, employee.Lastname, employee.Address, employee.City, employee.Email);

            table.Write();
        }

        private void DisplayDataFormatForGroupBy(List<EmployeeGroupDto> employeeList)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "CITY", "COUNT" },
                EnableCount = false
            });

            foreach (var employee in employeeList)
            {
                table.AddRow(
                    employee.City,
                    employee.Count
                    );
            }

            table.Write();
        }

        private void DisplayFullDataInTableFormat(List<EmployeeDto> employeeList)
        {
            var table = new ConsoleTable(new ConsoleTableOptions
            {
                Columns = new[] { "ID", "First Name", "Last Name", "Address", "City", "Email", "Designation" },
                EnableCount = false
            });

            foreach (var employee in employeeList)
            {
                table.AddRow(
                    employee.Id,
                    employee.Firstname,
                    employee.Lastname,
                    employee.Address,
                    employee.City,
                    employee.Email,
                    employee.Designation
                    );
            }

            table.Write();
        }
    }
}
