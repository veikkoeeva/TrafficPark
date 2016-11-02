using Autofac;
using TrafficPark.Builder.DataSources;
using TrafficPark.Builder.ViewModel;
using Xunit;

namespace TrafficPark.Builder.Tests
{
    public class MainViewModelTests
    {
        [WpfFact]
        public void IceBreaker()
        {
            ApplicationProperties.IsInTest = true;

            var builder = new ContainerBuilder();
            builder.RegisterType<InMemoryMasterDataSource>().As<IMasterDataSource>();
            builder.RegisterType<InMemoryChangeNotificationSource>().As<IChangeNotifications>();
            builder.RegisterType<Engine>().SingleInstance();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<TrafficSignViewModel>();
            ApplicationProperties.Container = builder.Build();

            App application = new App();
            application.InitializeComponent();


            //A Rx scheduler the control under test uses.
            //var testScheduler = new TestScheduler();

            application.MainWindow = new MainWindow();
            var mainViewModel = (MainViewModel)application.MainWindow.DataContext;
        }
    }
}
