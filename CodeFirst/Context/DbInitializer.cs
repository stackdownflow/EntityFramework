using CodeFirst.Enums;

namespace CodeFirst.Context
{
    public static class DbInitializer
    {
        public static void CreateDatabaseAndSeedData()
        {
            using (var context = new EmpDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();                

                InsertDesignationData(context);

                InsertEmployeeData(context);
            }            
        }

        private static void InsertDesignationData(EmpDbContext context)
        {
            List<Entities.Designation> desgList = new List<Entities.Designation>()
                    {
                        new Entities.Designation() { Name = "Executive Manager" },
                        new Entities.Designation() { Name = "Quality Analyst" },
                        new Entities.Designation() { Name = "Human Resource" },
                        new Entities.Designation() { Name = "Sr. Manager" },
                        new Entities.Designation() { Name = "Data Analyst" },
                        new Entities.Designation() { Name = "Sr. Analyst" }
                    };

            context.Designations.AddRange(desgList);
            context.SaveChanges();
        }

        private static void InsertEmployeeData(EmpDbContext context)
        {
            List<Entities.Employee> empList = new List<Entities.Employee>()
                    {
                       new Entities.Employee() { Firstname = "John", Lastname ="Doe", Address = "53 Avenue Street, NJ", City = "New Jersey", Email = "john.doe@deloitte.com", DesignationId = (int)Designation.Manager},
                       new Entities.Employee() { Firstname = "Jane", Lastname ="Doe", Address = "54 Avenue Street, NJ", City = "New Jersey", Email = "jane.doe@deloitte.com", DesignationId = (int)Designation.Manager },
                       new Entities.Employee() { Firstname = "Jose", Lastname = "Lopez", Address = "112 Brooklyn Street, CH", City = "Chicago", Email = "jose.lopez@deloitte.com", DesignationId =(int) Designation.QualityAssurance},
                       new Entities.Employee() { Firstname = "Diane", Lastname = "Carter", Address = "1802 Carriage Court, DC", City = "Washington DC", Email = "diane.carter@deloitte.com", DesignationId =(int) Designation.QualityAssurance},
                       new Entities.Employee() { Firstname = "Shawn", Lastname = "Foster", Address = "618 Broad Street, OH", City = "Ohio", Email = "shawn.foster@deloitte.com", DesignationId =(int) Designation.DataAnalyst},
                       new Entities.Employee() { Firstname = "Brenda", Lastname = "Fisher", Address = "619 Johnny Lane, MX", City = "Mexico", Email = "brenda.fisher@deloitte.com", DesignationId =(int) Designation.SrAnalyst},
                       new Entities.Employee() { Firstname = "Sean", Lastname = "Hunter", Address = "1352 Goff Avenue, NY", City = "New York", Email = "sean.hunter@deloitte.com", DesignationId =(int) Designation.SrManager}
                    };

            context.Employees.AddRange(empList);
            context.SaveChanges();
        }
    }
}
