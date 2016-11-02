using Autofac;
using Autofac.Extras.CommonServiceLocator;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using TrafficPark.Builder.DataSources;


namespace TrafficPark.Builder.ViewModel
{
    /// <summary>
    ///
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        ///
        /// </summary>
        public ViewModelLocator()
        {
            if(ApplicationProperties.Container == null && !ApplicationProperties.IsInTest)
            {
                var builder = new ContainerBuilder();
                builder.RegisterType<InMemoryMasterDataSource>().As<IMasterDataSource>();
                builder.RegisterType<InMemoryChangeNotificationSource>().As<IChangeNotifications>();
                if(ViewModelBase.IsInDesignModeStatic)
                {
                }
                else
                {
                }

                builder.RegisterType<Engine>().SingleInstance();
                builder.RegisterType<MainViewModel>();
                builder.RegisterType<TrafficSignViewModel>();
                ApplicationProperties.Container = builder.Build();
            }

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(ApplicationProperties.Container));
        }


        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();


        public TrafficSignViewModel LaiteViewModel => ServiceLocator.Current.GetInstance<TrafficSignViewModel>();


        public static void Cleanup() { }
    }
}