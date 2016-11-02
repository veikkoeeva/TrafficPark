using System.Collections.Generic;

namespace TrafficPark.Builder.DataTransferObjects
{
    public enum WarningSignState
    {
        None = 0,
        Jam = 1,
        Roadwork = 2,
        Wind = 3
    }


    public class AlteringWarningSignDto: TrafficSignDto
    {
        public WarningSignState WarningSign { get; set; }

        public IList<string> ColumnData { get; } = new List<string>();
    }
}
