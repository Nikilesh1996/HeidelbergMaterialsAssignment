using SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse;

namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class RocketSecondStage
    {
        public List<StagePayload> Payloads { get; set; }
    }
}
