namespace SpaceXSearchWebApp.Common.Models
{
    public class LaunchDetailsDto
    {
        public string FlightNumber { get; set; }
        public string RocketName { get; set; }
        public string RocketType { get; set; }
        public DateTime LaunchDateUtc { get; set; }
        public bool IsLaunchDateToBeDecided { get; set; }
        public string MissionName { get; set; }
    }
}
