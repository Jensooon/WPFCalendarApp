using Prism.Modularity;
using Prism.Regions;
using Prism.Ioc;
using CalendarApp.Views;

namespace CalendarApp.Navigation
{
    public class RegisterMenuNavigation : IModule
    {
        public RegisterMenuNavigation(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        private readonly IRegionManager _regionManager;
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView>();
            containerRegistry.RegisterForNavigation<SettingsView>();
        }
    }
}
