namespace SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse
{
    public class LaunchFailureDetails
    {
        public int time { get; set; }
        public int? altitude { get; set; }
        public string reason { get; set; }
    }
}
