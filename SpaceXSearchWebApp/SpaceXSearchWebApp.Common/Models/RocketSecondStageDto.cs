using SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse;

namespace SpaceXSearchWebApp.Common.Models
{
    public class RocketSecondStageDto
    {
        public List<StagePayloadDto> Payloads { get; set; }
    }
}
