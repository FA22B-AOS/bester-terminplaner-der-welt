namespace WpfApp1.Models
{
    public class Appointment
    {
        public string Title { get; set; }
        public DateTime Date { get; set; } // Das vollständige Datum und die Uhrzeit des Termins
        public int Hour { get; set; } // Stunde (wird über die ComboBox gesetzt)
        public int Minute { get; set; } // Minute (wird über die ComboBox gesetzt)
        public string Description { get; set; }
    }
}