namespace DoctorAppointment.Data.Configuration
{
    public class AppSettings
    {
        public DatabaseSettings Database { get; set; } = new DatabaseSettings();
    }

    public class DatabaseSettings
    {
        public EntitySettings Doctors { get; set; } = new EntitySettings();
        public EntitySettings Patients { get; set; } = new EntitySettings();
        public EntitySettings Appointments { get; set; } = new EntitySettings();
    }

    public class EntitySettings
    {
        public int LastId { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}

