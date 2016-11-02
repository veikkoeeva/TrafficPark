using System;
using System.Collections.Generic;
using TrafficPark.Builder.DataTransferObjects;


namespace TrafficPark.Builder.DataSources
{
    public class InMemoryMasterDataSource: IMasterDataSource
    {
        private List<TrafficParkDto> MainContents { get; set; } = new List<TrafficParkDto>(new[]
        {
            new TrafficParkDto { Name = "Traffic Park 1", Id = Guid.Parse("C51AC758-504B-4914-92DC-5EBE9A1F39E1"), Version = 1 },
            new TrafficParkDto { Name = "Traffic Park 2", Id = Guid.Parse("C51AC758-504B-4914-92DC-5EBE9A1F39E2"), Version = 1 }
        });

        private List<TrafficSignDto> CustomItemContents { get; set; } = new List<TrafficSignDto>(new TrafficSignDto[]
        {
            new SpeedLimitSignDto { TrafficParkId = Guid.Parse("C51AC758-504B-4914-92DC-5EBE9A1F39E1"), Name = "Speed limit: 80 km/h", Id = Guid.NewGuid(), SpeedLimit = SpeedLimitState.Eighty, Left = 100, Top = 100, Version = 1 },
            new AlteringWarningSignDto { TrafficParkId = Guid.Parse("C51AC758-504B-4914-92DC-5EBE9A1F39E1"), Name = "Warning: Jam", Id = Guid.NewGuid(), WarningSign = WarningSignState.Jam, Left = 200, Top = 200, Version = 1 },

            new AlteringWarningSignDto { TrafficParkId = Guid.Parse("C51AC758-504B-4914-92DC-5EBE9A1F39E2"), Name = "Warning: Windy", Id = Guid.NewGuid(), WarningSign = WarningSignState.Wind, Left = 100, Top = 100, Version = 1 }
        });


        public IEnumerable<TrafficParkDto> GetTrafficParks(IEnumerable<Guid> mainContentIds)
        {
            return MainContents;
        }


        public IEnumerable<TrafficSignDto> GetTrafficParkSigns(IEnumerable<Guid> itemTypeIds)
        {
            return CustomItemContents;
        }
    }
}
