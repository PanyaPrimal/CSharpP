using DoctorAppointment.Data.Configuration;
using DoctorAppointment.Data.Interfaces;
using DoctorAppointment.Domain.Entities;
using Newtonsoft.Json;

namespace DoctorAppointment.Data.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        public override string Path { get; set; }

        public override int LastId { get; set; }

        public PatientRepository()
        {
            var result = ReadFromAppSettings();

            Path = System.IO.Path.IsPathRooted(result.Database.Patients.Path) 
                ? result.Database.Patients.Path 
                : Constants.GetDataPath(result.Database.Patients.Path);
            LastId = result.Database.Patients.LastId;
        }

        public override void ShowInfo(Patient patient)
        {
            Console.WriteLine($"Patient: {patient.Name} {patient.Surname}, Illness: {patient.IllnessType}, Address: {patient.Address ?? "N/A"}");
        }

        protected override void SaveLastId()
        {
            var result = ReadFromAppSettings();
            result.Database.Patients.LastId = LastId;

            File.WriteAllText(Constants.AppSettingsPath, JsonConvert.SerializeObject(result, Formatting.Indented));
        }
    }
}
