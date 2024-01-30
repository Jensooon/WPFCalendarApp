using CalendarApp.Themes;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace CalendarApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "My calendar app";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            CurrentTheme = "LightTheme";

            ToggleThemeCommand = new DelegateCommand(ToggleTheme);

            DisplayDate = DateTime.Now;
        }

        #region Theme Handling
        private string currentTheme;
        public string CurrentTheme
        {
            get { return currentTheme; }
            set { SetProperty(ref currentTheme, value); }
        }

        private bool isLightTheme=true;
        public DelegateCommand ToggleThemeCommand { get; set; }

        private void ToggleTheme()
        {
            if (isLightTheme)
            {
                ToggleDarkTheme();
                isLightTheme = false;
            }
            else
            {
                ToggleLightTheme();
                isLightTheme = true;
            }
        }

        private void ToggleLightTheme()
        {
        ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
        }
        private void ToggleDarkTheme()
        {
        ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
        }
        #endregion

        public DateTime DisplayDate { get; set; }

    }
}
