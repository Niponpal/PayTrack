namespace PayTrack.Models
{
    public class HRNotice
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IssuedBy { get; set; } = string.Empty;
        public string TargetGroup { get; set; } = "All Employees";
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        public DateTime? ExpiryDate { get; set; }
        public bool IsImportant { get; set; } = false;
        public string? AttachmentUrl { get; set; }
        public string Status { get; set; } = "Active";
        public bool IsApproved { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
