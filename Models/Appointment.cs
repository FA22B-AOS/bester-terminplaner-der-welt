namespace WpfApp1.Models
{
    public class Appointment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }
}