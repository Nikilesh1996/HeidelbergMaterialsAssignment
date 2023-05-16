using AutoMapper;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Models;

namespace SpaceXSearchWebApp.Common.Mappings
{
    public class DomainModelToDtoMapper : Profile
    {

        public DomainModelToDtoMapper()
        {
            CreateMap<LaunchDetails, LaunchDetailsDto>();

            CreateMap<FlightLaunchInformation, FlightLaunchInformationDto>();
            CreateMap<RocketDetails, RocketDetailsDto>();
            CreateMap<ExternalLinks, ExternalLinksDto>();
            CreateMap<RocketFirstStage, RocketFirstStageDto>();
            CreateMap<RocketSecondStage, RocketSecondStageDto>();
            CreateMap<StagePayload, StagePayloadDto>();
            CreateMap<StageCore, StageCoreDto>();

            CreateMap<FlightLaunchQuery, FlightLaunchQueryDto>();
        }
    }
}
