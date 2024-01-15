using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Firstname { get; set; } = null!;
        [MaxLength(25)]
        public string Lastname { get; set; } = null!;
        [MaxLength(100)]
        public string Address { get; set; } = null!;
        [MaxLength(25)]
        public string City { get; set; } = null!;
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        public int DesignationId { get; set; }
        public virtual Designation DesignationNavigation { get; set; }
    }
}
