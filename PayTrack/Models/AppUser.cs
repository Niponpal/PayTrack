namespace WebApplication1.Models
{
    public class AppUser
    {
        public int ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Employee"; // Admin, HR, Employee
        public int? EmpID { get; set; }
    }
}
