using CalendarApp.Themes;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Threading;

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

        public MainWindowViewModel(IRegionManager regionManager)
        {
            CurrentTheme = "LightTheme";

            ToggleThemeCommand = new DelegateCommand(ToggleTheme);

            DisplayDate = DateTime.Now;

            //Side Menu Panel
            ToggleSidePanelCommand = new DelegateCommand(TogglePanel);
            SidePanelWidth = 40;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            isOpening = true;

            //Navigation
            m_regionManager = regionManager;
            NavigateMenu = new DelegateCommand<string>(NavigateToMenu);
            
        }

        #region Navigation
        private readonly IRegionManager m_regionManager;
        public DelegateCommand<string> NavigateMenu { get; private set; }

        private void NavigateToMenu(string viewMenu)
        {
            m_regionManager.RequestNavigate("ContentRegion", viewMenu);
        }
        #endregion

        #region Side Panel Handling
        private DispatcherTimer timer;
        private bool isOpening;

        private void TogglePanel()
        {
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isOpening)
            {
                sidePanelWidth += 4;
                if (sidePanelWidth >= 110) // Adjust as needed
                {
                    timer.Stop();
                    isOpening = false;
                }
            }
            else
            {
                sidePanelWidth -= 4;
                if (sidePanelWidth <= 40)
                {
                    timer.Stop();
                    isOpening = true;
                }
            }
            RaisePropertyChanged(nameof(SidePanelWidth));
        }

        public DelegateCommand ToggleSidePanelCommand { get; set; }

        private double sidePanelWidth;
        public double SidePanelWidth
        {
            get { return sidePanelWidth; }
            set { SetProperty(ref sidePanelWidth, value); }
        }
        #endregion

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
