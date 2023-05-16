using SpaceXSearchWebApp.Common.Abstractions.Models;

namespace SpaceXSearchWebApp.Common.Models
{
    public class RocketDetailsDto
    {
        public string RocketName { get; set; }
        public string RocketType { get; set; }

        public RocketFirstStageDto FirstStage { get; set; }
        public RocketSecondStageDto SecondStage { get; set; }
    }
}
