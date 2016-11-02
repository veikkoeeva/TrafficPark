using GalaSoft.MvvmLight;
using TrafficPark.Builder.DataTransferObjects;

namespace TrafficPark.Builder.ViewModel
{
    public class TrafficSignViewModel: ViewModelBase
    {
        private Engine Engine { get; }

        private TrafficSignDto  CustomItem { get; set; }

        public string Name { get; }

        public double Left { get; }

        public double Top { get; }


        public TrafficSignViewModel(Engine engine, TrafficSignDto sign)
        {
            Engine = engine;
            CustomItem = sign;
            Name = sign.Name;
            Left = sign.Left;
            Top = sign.Top;
        }
    }
}
