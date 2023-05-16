using SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse;

namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class RocketFirstStage
    {
        public List<StageCore> Cores { get; set; }
    }
}
