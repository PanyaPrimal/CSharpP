using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace DoctorAppointment.Data.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public AppointmentRepository()
        {
            var result = ReadFromAppSettings();

            Path = System.IO.Path.IsPathRooted(result.Database.Appointments.Path) 
                ? result.Database.Appointments.Path 
                : Constants.GetDataPath(result.Database.Appointments.Path);
            LastId = result.Database.Appointments.LastId;
        }

        public override void ShowInfo(Appointment appointment)
        {
            Console.WriteLine($"Appointment: Doctor {appointment.Doctor?.Name} {appointment.Doctor?.Surname} with Patient {appointment.Patient?.Name} {appointment.Patient?.Surname}");
            Console.WriteLine($"Time: {appointment.DateTimeFrom} - {appointment.DateTimeTo}");
            Console.WriteLine($"Description: {appointment.Description ?? "N/A"}");
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Appointments.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}
