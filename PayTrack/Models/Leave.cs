namespace WebApplication1.Models
{
    public class Leave
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } = string.Empty; // Casual, Sick, Paid
        public string Status { get; set; } = "Pending";
    }
}
