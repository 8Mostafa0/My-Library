using Autofac;
using My_Library.ViewModel;
using System.Windows;

namespace My_Library
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<MainWindow>();
                IMainViewModel mainViewModel = scope.Resolve<MainViewModel>();
                app.DataContext = mainViewModel;
                app.Show();
            }
        }
    }

}
