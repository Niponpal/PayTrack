namespace PayTrack.Models
{
    public class Notification
    {
        public int ID { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Unread";
    }
}
