using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TrafficPark.Builder.DataTransferObjects;


namespace TrafficPark.Builder.ViewModel
{
    public class TrafficParkViewModel: ViewModelBase
    {
        private ObservableCollection<TrafficSignViewModel> trafficSigns;

        private TrafficParkDto TrafficPark { get; set; }

        private ICommand switchTabCommand { get; set; }

        public string Name { get; }


        public bool isActive;


        public TrafficParkViewModel(Engine engine, TrafficParkDto trafficPark, bool isActive)
        {
            TrafficPark = trafficPark;
            Name = TrafficPark.Name;
            IsActive = isActive;

            var trafficSigns = engine.GetItemTypes().Where(i => i.TrafficParkId == TrafficPark.Id).Select(i => new TrafficSignViewModel(engine, i));
            TrafficSigns = new ObservableCollection<TrafficSignViewModel>(trafficSigns);
        }


        public ICommand TabSwitchCommand
        {
            get
            {
                return switchTabCommand ?? (switchTabCommand = new RelayCommand<TrafficParkViewModel>(tab =>
                {
                    try
                    {
                        //Do Engine stuff.
                    }
                    catch(Exception e)
                    {
                        //Show dialog?
                    }
                }, canExecute: param => true));
            }
        }


        public ObservableCollection<TrafficSignViewModel> TrafficSigns
        {
            get
            {
                return trafficSigns;
            }
            set
            {
                trafficSigns = value;
                RaisePropertyChanged(nameof(TrafficSigns));
            }
        }


        public bool IsActive
        {
            get
            {
                return isActive;
            }
            private set
            {
                isActive = value;
                RaisePropertyChanged(nameof(IsActive));
            }
        }
    }
}
