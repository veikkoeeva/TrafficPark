using System;
using TrafficPark.Builder.DataTransferObjects;

namespace TrafficPark.Builder.DataSources
{
    public interface IChangeNotifications
    {
        IObservable<TrafficParkChangeNotificationDto> TrafficSignChanges();

        IObservable<TrafficSignChangeDto> TrafficParkChanges();
    }
}
