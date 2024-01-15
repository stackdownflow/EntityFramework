using DatabaseFirst.Models;

namespace DatabaseFirst.Services
{
    public interface IEmployeeService
    {
        public void GetEmployees(bool isLambdaQuery = false);
        public void GetEmployeeById(int employeeId);
        public int AddNewEmployee(EmployeeDto employee);
        public void UpdateEmployee(int employeeId);
        public void DeleteEmployee(int employeeId);
        public void GetEmployeesBySkipping(bool isLambdaQuery = false);
        public void GetEmployeesByTaking(bool isLambdaQuery = false);
        public void GetEmployeesOrderByName(bool isLambdaQuery = false);
        public void GetEmployeesOrderByNameDesc(bool isLambdaQuery = false);
        public void GetEmployeesGroupBy(bool isLambdaQuery = false);
        public void GetFullDataOfEmployees(bool isLambdaQuery = false);
    }
}
