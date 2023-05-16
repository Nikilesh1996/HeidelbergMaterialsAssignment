

namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class FlightLaunchQuery
    {
        public int PageIndex { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
    }
}
