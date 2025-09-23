namespace PayTrack.Models
{
    public class SalaryComponent
    {
        public int ID { get; set; }
        public string ComponentName { get; set; } = string.Empty; // Bonus, Tax, Overtime
        public decimal Amount { get; set; }
    }
}
