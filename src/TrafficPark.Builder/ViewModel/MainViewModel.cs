using GalaSoft.MvvmLight;
using Logary;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace TrafficPark.Builder.ViewModel
{
    /// <summary>
    ///
    /// </summary>
    public class MainViewModel: ViewModelBase
    {
        private Engine Engine { get; }

        private Logger Logger { get; }

        private ObservableCollection<TrafficParkViewModel> trafficParks;


        [Obsolete("This constructor should be used only in design mode.", true)]
        public MainViewModel(): this(ServiceLocator.Current.GetInstance<Engine>())
        {
            if(!IsInDesignMode)
            {
                throw new InvalidOperationException("This constructor should be used only in design mode.");
            }
        }


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(Engine engine)
        {
            Engine = engine;

            var trafficParks = engine.GetTrafficParks().Select((i, ac) => new TrafficParkViewModel(engine, i, ac == 0));
            TrafficParks = new ObservableCollection<TrafficParkViewModel>(trafficParks);
        }


        public ObservableCollection<TrafficParkViewModel> TrafficParks
        {
            get
            {
                return trafficParks;
            }
            set
            {
                trafficParks = value;
                RaisePropertyChanged(nameof(TrafficParks));
            }
        }
    }
}