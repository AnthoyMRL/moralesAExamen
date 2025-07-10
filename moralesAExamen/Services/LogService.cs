namespace moralesAExamen.Services
{
    public class LogService
    {
        private readonly string _logFilePath;

        public LogService()
        {
            _logFilePath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Morales.txt");
        }

        public async Task WriteLogAsync(string movieTitle)
        {
            var logEntry = $"Se incluyó el registro [{movieTitle}] el {DateTime.Now:dd/MM/yyyy HH:mm}";

            try
            {
                await File.AppendAllTextAsync(_logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // Manejar error de escritura
                System.Diagnostics.Debug.WriteLine($"Error writing log: {ex.Message}");
            }
        }

        public async Task<List<string>> GetLogsAsync()
        {
            try
            {
                if (File.Exists(_logFilePath))
                {
                    var content = await File.ReadAllTextAsync(_logFilePath);
                    return content.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error reading logs: {ex.Message}");
            }

            return new List<string>();
        }
    }
}