using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Entities
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}