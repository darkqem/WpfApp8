using Prism.Modularity;
using System.Configuration;
using System.Data;
using System.Windows;
using Prism.Unity;
using Prism.Ioc;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class PrismApp : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<CounterViewModel>();
            containerRegistry.RegisterSingleton<CounterModule>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<CounterModule>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);
            Application.Current.MainWindow = shell;
            Application.Current.MainWindow.Show();
        }
    }

}
