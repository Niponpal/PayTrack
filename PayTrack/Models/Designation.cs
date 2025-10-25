namespace PayTrack.Models
{
    public class Designation
    {
        public int ID { get; set; }
        public string DesignationName { get; set; } = string.Empty;
        public string? Level { get; set; }

        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }
}
