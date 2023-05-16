namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class FlightLaunchInformation
    {
        public int FlightNumber { get; set; }
        public string MissionName { get; set; }
        public bool LaunchSuccess { get; set; }
        public string LaunchSite { get; set; }
        public DateTime LaunchDateUtc { get; set; }
        public bool IsLaunchDateToBeDecided { get; set; }
        public string Details { get; set; }
        public RocketDetails RocketDetails { get; set; }
        public ExternalLinks Links { get; set; }
    }
}
