using SpaceXSearchWebApp.Common.Abstractions.Models;

namespace SpaceXSearchWebApp.Common.Models
{
    public class RocketFirstStageDto
    {
        public List<StageCoreDto> Cores { get; set; }
    }
}
