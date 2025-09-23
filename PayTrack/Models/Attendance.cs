namespace PayTrack.Models
{
    public class Attendance
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
