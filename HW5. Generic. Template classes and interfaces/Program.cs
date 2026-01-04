using DoctorAppointment.Domain.Entities;
using DoctorAppointment.Domain.Enums;
using DoctorAppointment.Service.Interfaces;
using DoctorAppointment.Service.Services;

namespace DoctorAppointment
{
    public class DoctorAppointmentApp
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public DoctorAppointmentApp()
        {
            _doctorService = new DoctorService();
            _patientService = new PatientService();
            _appointmentService = new AppointmentService();
        }

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                var choice = GetMenuChoice();

                switch (choice)
                {
                    case MenuOptions.Exit:
                        return;
                    case MenuOptions.ShowAllDoctors:
                        ShowAllDoctors();
                        break;
                    case MenuOptions.ShowAllPatients:
                        ShowAllPatients();
                        break;
                    case MenuOptions.ShowAllAppointments:
                        ShowAllAppointments();
                        break;
                    case MenuOptions.CreateDoctor:
                        CreateDoctor();
                        break;
                    case MenuOptions.CreatePatient:
                        CreatePatient();
                        break;
                    case MenuOptions.CreateAppointment:
                        CreateAppointment();
                        break;
                    case MenuOptions.UpdateDoctor:
                        UpdateDoctor();
                        break;
                    case MenuOptions.UpdatePatient:
                        UpdatePatient();
                        break;
                    case MenuOptions.UpdateAppointment:
                        UpdateAppointment();
                        break;
                    case MenuOptions.DeleteDoctor:
                        DeleteDoctor();
                        break;
                    case MenuOptions.DeletePatient:
                        DeletePatient();
                        break;
                    case MenuOptions.DeleteAppointment:
                        DeleteAppointment();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("=== Doctor Appointment Management System ===");
            Console.WriteLine($"{(int)MenuOptions.ShowAllDoctors}. Show all doctors");
            Console.WriteLine($"{(int)MenuOptions.ShowAllPatients}. Show all patients");
            Console.WriteLine($"{(int)MenuOptions.ShowAllAppointments}. Show all appointments");
            Console.WriteLine($"{(int)MenuOptions.CreateDoctor}. Create doctor");
            Console.WriteLine($"{(int)MenuOptions.CreatePatient}. Create patient");
            Console.WriteLine($"{(int)MenuOptions.CreateAppointment}. Create appointment");
            Console.WriteLine($"{(int)MenuOptions.UpdateDoctor}. Update doctor");
            Console.WriteLine($"{(int)MenuOptions.UpdatePatient}. Update patient");
            Console.WriteLine($"{(int)MenuOptions.UpdateAppointment}. Update appointment");
            Console.WriteLine($"{(int)MenuOptions.DeleteDoctor}. Delete doctor");
            Console.WriteLine($"{(int)MenuOptions.DeletePatient}. Delete patient");
            Console.WriteLine($"{(int)MenuOptions.DeleteAppointment}. Delete appointment");
            Console.WriteLine($"{(int)MenuOptions.Exit}. Exit");
            Console.Write("Choose an option: ");
        }

        private MenuOptions GetMenuChoice()
        {
            if (int.TryParse(Console.ReadLine(), out int choice) && Enum.IsDefined(typeof(MenuOptions), choice))
            {
                return (MenuOptions)choice;
            }
            return (MenuOptions)(-1); // Invalid choice
        }

        private void ShowAllDoctors()
        {
            Console.WriteLine("\n=== All Doctors ===");
            var doctors = _doctorService.GetAll();
            if (!doctors.Any())
            {
                Console.WriteLine("No doctors found.");
                return;
            }

            foreach (var doctor in doctors)
            {
                Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name} {doctor.Surname}, Type: {doctor.DoctorType}, Experience: {doctor.Experience} years");
            }
        }

        private void ShowAllPatients()
        {
            Console.WriteLine("\n=== All Patients ===");
            var patients = _patientService.GetAll();
            if (!patients.Any())
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var patient in patients)
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name} {patient.Surname}, Illness: {patient.IllnessType}, Address: {patient.Address ?? "N/A"}");
            }
        }

        private void ShowAllAppointments()
        {
            Console.WriteLine("\n=== All Appointments ===");
            var appointments = _appointmentService.GetAll();
            if (!appointments.Any())
            {
                Console.WriteLine("No appointments found.");
                return;
            }

            foreach (var appointment in appointments)
            {
                Console.WriteLine($"ID: {appointment.Id}, Doctor: {appointment.Doctor?.Name} {appointment.Doctor?.Surname}, Patient: {appointment.Patient?.Name} {appointment.Patient?.Surname}");
                Console.WriteLine($"Time: {appointment.DateTimeFrom} - {appointment.DateTimeTo}, Description: {appointment.Description ?? "N/A"}");
                Console.WriteLine();
            }
        }

        private void CreateDoctor()
        {
            Console.WriteLine("\n=== Create Doctor ===");
            var doctor = new Doctor();

            Console.Write("Name: ");
            doctor.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("Surname: ");
            doctor.Surname = Console.ReadLine() ?? string.Empty;

            Console.Write("Phone: ");
            doctor.Phone = Console.ReadLine();

            Console.Write("Email: ");
            doctor.Email = Console.ReadLine();

            Console.Write("Experience (years): ");
            if (byte.TryParse(Console.ReadLine(), out byte experience))
            {
                doctor.Experience = experience;
            }

            Console.Write("Salary: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                doctor.Salary = salary;
            }

            Console.WriteLine("Doctor types:");
            foreach (var type in Enum.GetValues<DoctorTypes>())
            {
                Console.WriteLine($"{(int)type}. {type}");
            }
            Console.Write("Choose doctor type: ");
            if (int.TryParse(Console.ReadLine(), out int typeChoice) && Enum.IsDefined(typeof(DoctorTypes), typeChoice))
            {
                doctor.DoctorType = (DoctorTypes)typeChoice;
            }

            var createdDoctor = _doctorService.Create(doctor);
            Console.WriteLine($"Doctor created successfully with ID: {createdDoctor.Id}");
        }

        private void CreatePatient()
        {
            Console.WriteLine("\n=== Create Patient ===");
            var patient = new Patient();

            Console.Write("Name: ");
            patient.Name = Console.ReadLine() ?? string.Empty;

            Console.Write("Surname: ");
            patient.Surname = Console.ReadLine() ?? string.Empty;

            Console.Write("Phone: ");
            patient.Phone = Console.ReadLine();

            Console.Write("Email: ");
            patient.Email = Console.ReadLine();

            Console.Write("Address: ");
            patient.Address = Console.ReadLine();

            Console.Write("Additional info: ");
            patient.AdditionalInfo = Console.ReadLine();

            Console.WriteLine("Illness types:");
            foreach (var type in Enum.GetValues<IllnessTypes>())
            {
                Console.WriteLine($"{(int)type}. {type}");
            }
            Console.Write("Choose illness type: ");
            if (int.TryParse(Console.ReadLine(), out int typeChoice) && Enum.IsDefined(typeof(IllnessTypes), typeChoice))
            {
                patient.IllnessType = (IllnessTypes)typeChoice;
            }

            var createdPatient = _patientService.Create(patient);
            Console.WriteLine($"Patient created successfully with ID: {createdPatient.Id}");
        }

        private void CreateAppointment()
        {
            Console.WriteLine("\n=== Create Appointment ===");

            ShowAllDoctors();
            Console.Write("Choose doctor ID: ");
            if (!int.TryParse(Console.ReadLine(), out int doctorId))
            {
                Console.WriteLine("Invalid doctor ID.");
                return;
            }

            var doctor = _doctorService.Get(doctorId);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            ShowAllPatients();
            Console.Write("Choose patient ID: ");
            if (!int.TryParse(Console.ReadLine(), out int patientId))
            {
                Console.WriteLine("Invalid patient ID.");
                return;
            }

            var patient = _patientService.Get(patientId);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            var appointment = new Appointment
            {
                Doctor = doctor,
                Patient = patient
            };

            Console.Write("Date and time from (yyyy-MM-dd HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateTimeFrom))
            {
                appointment.DateTimeFrom = dateTimeFrom;
            }

            Console.Write("Date and time to (yyyy-MM-dd HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateTimeTo))
            {
                appointment.DateTimeTo = dateTimeTo;
            }

            Console.Write("Description: ");
            appointment.Description = Console.ReadLine();

            var createdAppointment = _appointmentService.Create(appointment);
            Console.WriteLine($"Appointment created successfully with ID: {createdAppointment.Id}");
        }

        private void UpdateDoctor()
        {
            ShowAllDoctors();
            Console.Write("Enter doctor ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var doctor = _doctorService.Get(id);
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.Write($"Name ({doctor.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) doctor.Name = name;

            Console.Write($"Surname ({doctor.Surname}): ");
            var surname = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(surname)) doctor.Surname = surname;

            Console.Write($"Phone ({doctor.Phone}): ");
            var phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone)) doctor.Phone = phone;

            Console.Write($"Email ({doctor.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) doctor.Email = email;

            Console.Write($"Experience ({doctor.Experience}): ");
            if (byte.TryParse(Console.ReadLine(), out byte experience))
            {
                doctor.Experience = experience;
            }

            Console.Write($"Salary ({doctor.Salary}): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal salary))
            {
                doctor.Salary = salary;
            }

            Console.WriteLine("Doctor types:");
            foreach (var type in Enum.GetValues<DoctorTypes>())
            {
                Console.WriteLine($"{(int)type}. {type}");
            }
            Console.Write($"Choose doctor type ({doctor.DoctorType}): ");
            if (int.TryParse(Console.ReadLine(), out int typeChoice) && Enum.IsDefined(typeof(DoctorTypes), typeChoice))
            {
                doctor.DoctorType = (DoctorTypes)typeChoice;
            }

            _doctorService.Update(id, doctor);
            Console.WriteLine("Doctor updated successfully.");
        }

        private void UpdatePatient()
        {
            ShowAllPatients();
            Console.Write("Enter patient ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var patient = _patientService.Get(id);
            if (patient == null)
            {
                Console.WriteLine("Patient not found.");
                return;
            }

            Console.Write($"Name ({patient.Name}): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) patient.Name = name;

            Console.Write($"Surname ({patient.Surname}): ");
            var surname = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(surname)) patient.Surname = surname;

            Console.Write($"Phone ({patient.Phone}): ");
            var phone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(phone)) patient.Phone = phone;

            Console.Write($"Email ({patient.Email}): ");
            var email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) patient.Email = email;

            Console.Write($"Address ({patient.Address}): ");
            var address = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(address)) patient.Address = address;

            Console.Write($"Additional info ({patient.AdditionalInfo}): ");
            var additionalInfo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(additionalInfo)) patient.AdditionalInfo = additionalInfo;

            Console.WriteLine("Illness types:");
            foreach (var type in Enum.GetValues<IllnessTypes>())
            {
                Console.WriteLine($"{(int)type}. {type}");
            }
            Console.Write($"Choose illness type ({patient.IllnessType}): ");
            if (int.TryParse(Console.ReadLine(), out int typeChoice) && Enum.IsDefined(typeof(IllnessTypes), typeChoice))
            {
                patient.IllnessType = (IllnessTypes)typeChoice;
            }

            _patientService.Update(id, patient);
            Console.WriteLine("Patient updated successfully.");
        }

        private void UpdateAppointment()
        {
            ShowAllAppointments();
            Console.Write("Enter appointment ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var appointment = _appointmentService.Get(id);
            if (appointment == null)
            {
                Console.WriteLine("Appointment not found.");
                return;
            }

            ShowAllDoctors();
            Console.Write($"Choose doctor ID ({appointment.Doctor?.Id}): ");
            if (int.TryParse(Console.ReadLine(), out int doctorId))
            {
                var doctor = _doctorService.Get(doctorId);
                if (doctor != null)
                {
                    appointment.Doctor = doctor;
                }
            }

            ShowAllPatients();
            Console.Write($"Choose patient ID ({appointment.Patient?.Id}): ");
            if (int.TryParse(Console.ReadLine(), out int patientId))
            {
                var patient = _patientService.Get(patientId);
                if (patient != null)
                {
                    appointment.Patient = patient;
                }
            }

            Console.Write($"Date and time from ({appointment.DateTimeFrom}): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateTimeFrom))
            {
                appointment.DateTimeFrom = dateTimeFrom;
            }

            Console.Write($"Date and time to ({appointment.DateTimeTo}): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateTimeTo))
            {
                appointment.DateTimeTo = dateTimeTo;
            }

            Console.Write($"Description ({appointment.Description}): ");
            var description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description)) appointment.Description = description;

            _appointmentService.Update(id, appointment);
            Console.WriteLine("Appointment updated successfully.");
        }

        private void DeleteDoctor()
        {
            ShowAllDoctors();
            Console.Write("Enter doctor ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            if (_doctorService.Delete(id))
            {
                Console.WriteLine("Doctor deleted successfully.");
            }
            else
            {
                Console.WriteLine("Doctor not found.");
            }
        }

        private void DeletePatient()
        {
            ShowAllPatients();
            Console.Write("Enter patient ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            if (_patientService.Delete(id))
            {
                Console.WriteLine("Patient deleted successfully.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        private void DeleteAppointment()
        {
            ShowAllAppointments();
            Console.Write("Enter appointment ID to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            if (_appointmentService.Delete(id))
            {
                Console.WriteLine("Appointment deleted successfully.");
            }
            else
            {
                Console.WriteLine("Appointment not found.");
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var app = new DoctorAppointmentApp();
            app.Run();
        }
    }
}