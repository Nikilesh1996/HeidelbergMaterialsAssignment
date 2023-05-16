namespace SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse
{
    public class Fairings
    {
        public bool? reused { get; set; }
        public bool? recovery_attempt { get; set; }
        public bool? recovered { get; set; }
        public string ship { get; set; }
    }
}
