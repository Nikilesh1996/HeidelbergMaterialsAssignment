using SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse;

namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class RocketDetails
    {
        public string RocketName {get;set;}
        public string RocketType { get; set; }

        public RocketFirstStage FirstStage { get; set; }
        public RocketSecondStage SecondStage { get; set; }
    }
}
