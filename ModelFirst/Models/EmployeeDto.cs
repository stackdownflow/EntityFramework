namespace ModelFirst.Models
{
    public partial class EmployeeDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int DesgId { get; set; }
        public string Designation { get; set; } = string.Empty;
    }
}
