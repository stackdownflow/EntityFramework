using System;
using System.Collections.Generic;

namespace DatabaseFirst.Entities;

public partial class Designation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
