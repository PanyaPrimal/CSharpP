namespace DoctorAppointment.Data.Configuration
{
    public static class Constants
    {
        private static string? _projectRoot;
        
        private static string ProjectRoot
        {
            get
            {
                if (_projectRoot == null)
                {
                    var currentDir = AppDomain.CurrentDomain.BaseDirectory;
                    
                    var directory = new DirectoryInfo(currentDir);
                    while (directory != null)
                    {
                        var appSettingsPath = Path.Combine(directory.FullName, "Data", "Configuration", "appsettings.json");
                        if (File.Exists(appSettingsPath))
                        {
                            _projectRoot = directory.FullName;
                            return _projectRoot;
                        }
                        directory = directory.Parent;
                    }
                    
                    _projectRoot = Directory.GetCurrentDirectory();
                }
                return _projectRoot;
            }
        }
        
        public static string AppSettingsPath
        {
            get
            {
                var path = Path.Combine(ProjectRoot, "Data", "Configuration", "appsettings.json");
                return Path.GetFullPath(path);
            }
        }
        
        public static string GetDataPath(string relativePath)
        {
            var path = Path.Combine(ProjectRoot, relativePath);
            return Path.GetFullPath(path);
        }
    }
}

