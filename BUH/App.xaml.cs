using System.Windows;
using BUH.Config.AutoMapper;
using BUH.Domain.Providers.Abstraction;
using BUH.Domain.Providers.Concrete;
using Ninject;

namespace BUH
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            this.container = new StandardKernel(
                new AutoMapperModule(),
                new ProvidersModule(),
                new RepositoriesModule(),
                new ServicesModule());
        }

        private void ComposeObjects()
        {
            Current.MainWindow = this.container.Get<MainWindow>();
        }
    }
}
