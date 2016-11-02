using System;


namespace TrafficPark.Builder.DataTransferObjects
{
    public enum TrafficState
    {
        None = 0,
        Active = 1,
        Deactive = 2
    }


    public abstract class TrafficSignDto
    {
        public Guid TrafficParkId { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Left { get; set; }

        public double Top { get; set; }

        public int Version { get; set; }
    }
}
