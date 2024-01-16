using ConsoleTables;
using ModelFirst.DatabaseModel;
using ModelFirst.Models;
using System;
using System.Linq;

namespace ModelFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new EmployeeContainer())
            {
                var result = context.Employees.Join(
                                 context.Designations,
                                 e => e.DesignationId,
                                 d => d.DesignationId,
                                 (e, d) => new EmployeeDto()
                                 {
                                     Id = e.ID,
                                     Firstname = e.FirstName,
                                     Lastname = e.LastName,
                                     Address = e.Address,
                                     City = e.City,
                                     Email = e.Email,
                                     Designation = d.Name
                                 }).ToList();


                var table = new ConsoleTable(new ConsoleTableOptions
                {
                    Columns = new[] { "ID", "First Name", "Last Name", "Address", "City", "Email", "Designation" },
                    EnableCount = false
                });

                foreach (var employee in result)
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

            Console.ReadLine();
        }
    }
}
