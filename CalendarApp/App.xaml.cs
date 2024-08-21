using CalendarApp.Navigation;
using CalendarApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Windows;
using CalendarApp.Dialogs;

namespace CalendarApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            
            var window =  this.Container.Resolve<MainWindow>();

            window.Loaded += (sender, args) =>
            {
                var manager = this.Container.Resolve<IRegionManager>();

                manager.RequestNavigate("ContentRegion", "HomeView");
            };
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<SaveAsDialog, SaveDialogAsViewModel>();
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<RegisterMenuNavigation>();
        }
    }
}
