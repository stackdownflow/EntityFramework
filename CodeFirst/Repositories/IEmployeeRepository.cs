using CodeFirst.Models;

namespace CodeFirst.Repositories
{
    public interface IEmployeeRepository
    {
        public List<EmployeeDto> GetEmployees(bool isLambdaQuery = false);
        public EmployeeDto? GetEmployeeById(int employeeId);
        public int AddNewEmployee(EmployeeDto employee);
        public void UpdateEmployee(int employeeId);
        public void DeleteEmployee(int employeeId);
        public List<EmployeeDto> GetEmployeesBySkipping(bool isLambdaQuery = false);
        public List<EmployeeDto> GetEmployeesByTaking(bool isLambdaQuery = false);
        public List<EmployeeDto> GetEmployeesOrderByName(bool isLambdaQuery = false);
        public List<EmployeeDto> GetEmployeesOrderByNameDesc(bool isLambdaQuery = false);
        public List<EmployeeGroupDto> GetEmployeesGroupBy(bool isLambdaQuery = false);
        public List<EmployeeDto> GetFullDataOfEmployees(bool isLambdaQuery = false);
    }
}
