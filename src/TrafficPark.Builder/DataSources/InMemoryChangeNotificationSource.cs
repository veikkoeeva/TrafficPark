using System;
using TrafficPark.Builder.DataTransferObjects;


namespace TrafficPark.Builder.DataSources
{
    public class InMemoryChangeNotificationSource: IChangeNotifications
    {
        public IObservable<TrafficParkChangeNotificationDto> TrafficSignChanges()
        {
            throw new NotImplementedException();
        }


        public IObservable<TrafficSignChangeDto> TrafficParkChanges()
        {
            throw new NotImplementedException();
        }
    }
}
