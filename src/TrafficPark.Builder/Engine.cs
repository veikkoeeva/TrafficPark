using System;
using System.Collections.Generic;
using TrafficPark.Builder.DataSources;
using TrafficPark.Builder.DataTransferObjects;


namespace TrafficPark.Builder
{  
    public class Engine
    {
        private IMasterDataSource MasterDataSource { get; }
        private IChangeNotifications ChangeNotifications { get; }

        private List<TrafficParkDto> MainContents { get; } = new List<TrafficParkDto>();
        private List<TrafficSignDto> CustomItemContents { get; } = new List<TrafficSignDto>();
                

        public IObservable<TrafficParkDto> MainContentChanges { get; }

        public IObservable<TrafficSignDto> CustomItemTypeChanges { get; }


        public Engine(IMasterDataSource masterDataSource, IChangeNotifications changeNotifications)
        {
            MasterDataSource = masterDataSource;
            ChangeNotifications = changeNotifications;

            MainContents.AddRange(MasterDataSource.GetTrafficParks(new[] { Guid.Empty }));
            CustomItemContents.AddRange(MasterDataSource.GetTrafficParkSigns(new[] { Guid.Empty }));
        }


        public IEnumerable<TrafficParkDto> GetTrafficParks()
        {
            return MainContents;
        }

        public IEnumerable<TrafficSignDto> GetItemTypes()
        {
            return CustomItemContents;
        }
    }
}
