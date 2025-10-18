namespace PayTrack.Models
{
    public class Payroll
    {
        public int ID { get; set; }
        public string MonthYear { get; set; }
        public decimal Basic { get; set; }
        public decimal Allowance { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetPay { get; set; }
        public DateTime GeneratedDate { get; set; } = DateTime.Now;
    }
}
