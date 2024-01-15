using CodeFirst.Context;
using CodeFirst.Entities;
using CodeFirst.Models;

namespace CodeFirst.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EmpDbContext _empDbContext;

        public EmployeeRepository(EmpDbContext empDbContext)
        {
            _empDbContext = empDbContext;
        }

        public int AddNewEmployee(EmployeeDto e)
        {
            var employee = new Employee()
            {
                Firstname = e.Firstname,
                Lastname = e.Lastname,
                Address = e.Address,
                City = e.City,
                Email = e.Email,
                DesignationId = e.DesgId
            };
            var newRecord = _empDbContext.Add(employee);
            _empDbContext.SaveChanges();

            return newRecord.Entity.Id;
        }

        public void DeleteEmployee(int employeeId)
        {
            var record = _empDbContext.Employees.Where(x => x.Id == employeeId).First();
            _empDbContext.Employees.Remove(record);
            _empDbContext.SaveChanges();
        }

        public EmployeeDto? GetEmployeeById(int employeeId)
        {
            return _empDbContext.Employees
                    .Where(x => x.Id == employeeId).Select(e => new EmployeeDto()
                    {
                        Id = e.Id,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        Address = e.Address,
                        City = e.City,
                        Email = e.Email
                    }).SingleOrDefault(); ;
        }

        public List<EmployeeDto> GetEmployees(bool isLambdaQuery = false)
        {
            if (isLambdaQuery)
                return _empDbContext.Employees
                        .Select(e => new EmployeeDto()
                        {
                            Id = e.Id,
                            Firstname = e.Firstname,
                            Lastname = e.Lastname,
                            Address = e.Address,
                            City = e.City,
                            Email = e.Email
                        }).ToList();

            return (from e in _empDbContext.Employees
                    select new EmployeeDto()
                    {
                        Id = e.Id,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        Address = e.Address,
                        City = e.City,
                        Email = e.Email
                    }).ToList();
        }

        public List<EmployeeDto> GetEmployeesBySkipping(bool isLambdaQuery = false)
        {
            if (isLambdaQuery)
                return _empDbContext.Employees.Skip(2)
                        .Select(e => new EmployeeDto()
                        {
                            Id = e.Id,
                            Firstname = e.Firstname,
                            Lastname = e.Lastname,
                            Address = e.Address,
                            City = e.City,
                            Email = e.Email
                        }).ToList();

            return (from e in _empDbContext.Employees.Skip(2)
                    select new EmployeeDto()
                    {
                        Id = e.Id,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        Address = e.Address,
                        City = e.City,
                        Email = e.Email
                    }).ToList();
        }

        public List<EmployeeDto> GetEmployeesByTaking(bool isLambdaQuery = false)
        {
            if (isLambdaQuery)
                return _empDbContext.Employees.Take(4)
                        .Select(e => new EmployeeDto()
                        {
                            Id = e.Id,
                            Firstname = e.Firstname,
                            Lastname = e.Lastname,
                            Address = e.Address,
                            City = e.City,
                            Email = e.Email
                        }).ToList();

            return (from e in _empDbContext.Employees.Take(4)
                    select new EmployeeDto()
                    {
                        Id = e.Id,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        Address = e.Address,
                        City = e.City,
                        Email = e.Email
                    }).ToList();
        }

        public List<EmployeeGroupDto> GetEmployeesGroupBy(bool isLambdaQuery = false)
        {
            if (isLambdaQuery)
                return _empDbContext.Employees
                        .GroupBy(x => x.City, (key, e) => new EmployeeGroupDto()
                        {
                            City = key,
                            Count = e.Count()
                        }).ToList();

            return (from e in _empDbContext.Employees
                    group e by e.City into temp
                    select new EmployeeGroupDto()
                    {
                        City = temp.Key,
                        Count = temp.Count()
                    }).ToList();
        }

        public List<EmployeeDto> GetEmployeesOrderByName(bool isLambdaQuery = false)
        {
            if (isLambdaQuery)
                return _empDbContext.Employees
                        .Select(e => new EmployeeDto()
                        {
                            Id = e.Id,
                            Firstname = e.Firstname,
                            Lastname = e.Lastname,
                            Address = e.Address,
                            City = e.City,
                            Email = e.Email
                        }).OrderBy(x => x.Firstname).ToList();

            return (from e in _empDbContext.Employees
                    orderby e.Firstname
                    select new EmployeeDto()
                    {
                        Id = e.Id,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        Address = e.Address,
                        City = e.City,
                        Email = e.Email
                    }).ToList();
        }

        public List<EmployeeDto> GetEmployeesOrderByNameDesc(bool isLambdaQuery = false)
        {
            if (isLambdaQuery)
                return _empDbContext.Employees
                        .Select(e => new EmployeeDto()
                        {
                            Id = e.Id,
                            Firstname = e.Firstname,
                            Lastname = e.Lastname,
                            Address = e.Address,
                            City = e.City,
                            Email = e.Email,
                        }).OrderByDescending(x => x.Firstname).ToList();

            return (from e in _empDbContext.Employees
                    orderby e.Firstname descending
                    select new EmployeeDto()
                    {
                        Id = e.Id,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        Address = e.Address,
                        City = e.City,
                        Email = e.Email
                    }).ToList();
        }

        public List<EmployeeDto> GetFullDataOfEmployees(bool isLambdaQuery = false)
        {
            if (isLambdaQuery)
                return _empDbContext.Employees.Join(
                            _empDbContext.Designations,
                            e => e.DesignationId,
                            d => d.DesignationId,
                            (e, d) => new EmployeeDto()
                            {
                                Id = e.Id,
                                Firstname = e.Firstname,
                                Lastname = e.Lastname,
                                Address = e.Address,
                                City = e.City,
                                Email = e.Email,
                                Designation = d.Name
                            }).ToList();

            return (from e in _empDbContext.Employees
                    join d in _empDbContext.Designations on e.DesignationId equals d.DesignationId
                    select new EmployeeDto()
                    {
                        Id = e.Id,
                        Firstname = e.Firstname,
                        Lastname = e.Lastname,
                        Address = e.Address,
                        City = e.City,
                        Email = e.Email,
                        Designation = d.Name
                    }).ToList();
        }

        public void UpdateEmployee(int employeeId)
        {
            var record = _empDbContext.Employees.Where(x => x.Id == employeeId).First();
            record.Firstname = "UpdatedFirstName";
            _empDbContext.SaveChanges();
        }
    }
}
