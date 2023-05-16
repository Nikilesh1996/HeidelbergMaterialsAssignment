using SpaceXSearchWebApp.Common.Abstractions.Models;

namespace SpaceXSearchWebApp.Common.Models
{
    public class FlightLaunchInformationDto
    {
        public int FlightNumber { get; set; }
        public string MissionName { get; set; }
        public bool LaunchSuccess { get; set; }
        public string LaunchSite { get; set; }
        public DateTime LaunchDateUtc { get; set; }
        public bool IsLaunchDateToBeDecided { get; set; }
        public string Details { get; set; }
        public RocketDetailsDto RocketDetails { get; set; }
        public ExternalLinksDto Links { get; set; }

    }
}
