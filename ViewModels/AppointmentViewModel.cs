using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfApp1.Models;

namespace WpfApp1.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {
        public ObservableCollection<Appointment> Appointments { get; set; }
        public Appointment NewAppointment { get; set; }

        public ICommand AddAppointmentCommand { get; set; }
        public ICommand DeleteAppointmentCommand { get; set; }

        // ObservableCollection für Stunden und Minuten
        public ObservableCollection<int> Hours { get; set; }
        public ObservableCollection<int> Minutes { get; set; }

        public AppointmentViewModel()
        {
            // Initialisierung der Listen für Stunden und Minuten
            Hours = new ObservableCollection<int>(Enumerable.Range(0, 24));
            Minutes = new ObservableCollection<int>(Enumerable.Range(0, 60));

            Appointments = new ObservableCollection<Appointment>();
            NewAppointment = new Appointment();

            AddAppointmentCommand = new RelayCommand(AddAppointment);
            DeleteAppointmentCommand = new RelayCommand<Appointment>(DeleteAppointment);
        }

        private void AddAppointment()
        {
            if (!string.IsNullOrWhiteSpace(NewAppointment.Title) && NewAppointment.Date > DateTime.Now.Date)
            {
                // Uhrzeit zum Termin hinzufügen
                NewAppointment.Date = NewAppointment.Date.AddHours(NewAppointment.Hour).AddMinutes(NewAppointment.Minute);

                // Termin zur Liste hinzufügen
                Appointments.Add(new Appointment
                {
                    Title = NewAppointment.Title,
                    Date = NewAppointment.Date,
                    Description = NewAppointment.Description
                });

                // Formular zurücksetzen
                NewAppointment = new Appointment();
                OnPropertyChanged(nameof(NewAppointment));
            }
        }

        private void DeleteAppointment(Appointment appointment)
        {
            if (appointment != null)
            {
                Appointments.Remove(appointment);
            }
        }
    }
}
