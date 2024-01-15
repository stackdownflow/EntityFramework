using System;
using System.Collections.Generic;

namespace DatabaseFirst.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? Designation { get; set; }

    public virtual Designation? DesignationNavigation { get; set; }
}
