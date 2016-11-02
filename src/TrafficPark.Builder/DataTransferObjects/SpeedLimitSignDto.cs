

namespace TrafficPark.Builder.DataTransferObjects
{
    public enum SpeedLimitState
    {
        None = 0,
        Sixty = 1,
        Seventy = 2,
        Eighty = 3
    }


    public class SpeedLimitSignDto: TrafficSignDto
    {
        public SpeedLimitState SpeedLimit { get; set; }
    }
}
