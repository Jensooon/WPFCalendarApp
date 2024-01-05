using CalendarApp.Themes;
using Prism.Commands;
using Prism.Mvvm;

namespace CalendarApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string currentTheme;
        public string CurrentTheme
        {
            get { return currentTheme; }
            set { SetProperty(ref currentTheme, value); }
        }

        public DelegateCommand ToggleLightThemeCommand { get; set; }
        public DelegateCommand ToggleDarkThemeCommand { get; set; }

        public MainWindowViewModel()
        {
            CurrentTheme = "LightTheme";

            ToggleLightThemeCommand = new DelegateCommand(ToggleLightTheme);
            ToggleDarkThemeCommand = new DelegateCommand(ToggleDarkTheme);
        }

        private void ToggleLightTheme()
        {
        ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
        }
        private void ToggleDarkTheme()
        {
        ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
        }
    }
}
