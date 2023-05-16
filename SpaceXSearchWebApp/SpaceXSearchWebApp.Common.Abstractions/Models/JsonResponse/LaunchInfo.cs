namespace SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse
{
    public class LaunchInfo
    {
        public int flight_number { get; set; }
        public string mission_name { get; set; }
        public List<string> mission_id { get; set; }
        public bool upcoming { get; set; }
        public string launch_year { get; set; }
        public int launch_date_unix { get; set; }
        public DateTime launch_date_utc { get; set; }
        public DateTime launch_date_local { get; set; }
        public bool is_tentative { get; set; }
        public string tentative_max_precision { get; set; }
        public bool tbd { get; set; }
        public int? launch_window { get; set; }
        public Rocket rocket { get; set; }
        public List<string> ships { get; set; }
        public Telemetry telemetry { get; set; }
        public LaunchSite launch_site { get; set; }
        public bool? launch_success { get; set; }
        public LaunchFailureDetails launch_failure_details { get; set; }
        public Links links { get; set; }
        public string details { get; set; }
        public DateTime? static_fire_date_utc { get; set; }
        public int? static_fire_date_unix { get; set; }
        public Timeline timeline { get; set; }
    }
}
