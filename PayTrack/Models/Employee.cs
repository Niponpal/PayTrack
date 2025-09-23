namespace WebApplication1.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public DateTime JoiningDate { get; set; }
        public decimal SalaryBase { get; set; }
        public string Status { get; set; } = "Active";
    }
}
