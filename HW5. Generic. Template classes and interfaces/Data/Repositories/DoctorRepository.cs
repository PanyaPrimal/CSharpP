using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace DoctorAppointment.Data.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public DoctorRepository()
        {
            var result = ReadFromAppSettings();

            Path = System.IO.Path.IsPathRooted(result.Database.Doctors.Path) 
                ? result.Database.Doctors.Path 
                : Constants.GetDataPath(result.Database.Doctors.Path);
            LastId = result.Database.Doctors.LastId;
        }

        public override void ShowInfo(Doctor doctor)
        {
            Console.WriteLine($"Doctor: {doctor.Name} {doctor.Surname}, Type: {doctor.DoctorType}, Experience: {doctor.Experience} years");
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Doctors.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}
