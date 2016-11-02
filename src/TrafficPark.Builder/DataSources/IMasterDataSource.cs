using System;
using System.Collections.Generic;
using TrafficPark.Builder.DataTransferObjects;


namespace TrafficPark.Builder.DataSources
{
    public interface IMasterDataSource
    {
        IEnumerable<TrafficParkDto> GetTrafficParks(IEnumerable<Guid> trafficParkIds);

        IEnumerable<TrafficSignDto> GetTrafficParkSigns(IEnumerable<Guid> trafficSignDtos);
    }
}
