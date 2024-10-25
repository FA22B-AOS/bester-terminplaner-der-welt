using System.Collections.ObjectModel;
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

        public AppointmentViewModel()
        {
            Appointments = new ObservableCollection<Appointment>();
            NewAppointment = new Appointment();

            AddAppointmentCommand = new RelayCommand(AddAppointment);
            DeleteAppointmentCommand = new RelayCommand<Appointment>(DeleteAppointment);
        }

        private void AddAppointment()
        {
            if (!string.IsNullOrWhiteSpace(NewAppointment.Title) && NewAppointment.Date > DateTime.Now)
            {
                Appointments.Add(new Appointment
                {
                    Title = NewAppointment.Title,
                    Date = NewAppointment.Date,
                    Description = NewAppointment.Description
                });
                NewAppointment = new Appointment(); // Reset the form
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