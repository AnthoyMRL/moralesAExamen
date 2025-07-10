using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using moralesAExamen.Services;
using System.Collections.ObjectModel;

namespace moralesAExamen.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        private readonly LogService _logService;

        [ObservableProperty]
        private ObservableCollection<string> logs = new();

        public LogsViewModel(LogService logService)
        {
            _logService = logService;
        }

        [RelayCommand]
        private async Task LoadLogs()
        {
            var logList = await _logService.GetLogsAsync();
            Logs.Clear();

            foreach (var log in logList)
            {
                Logs.Add(log);
            }
        }

        public async Task OnAppearing()
        {
            await LoadLogs();
        }
    }
}