using AutoMapper;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Models;

namespace SpaceXSearchWebApp.Common.Mappings
{
    public class DtoToDomainModelMapper : Profile
    {
        public DtoToDomainModelMapper()
        {
            CreateMap<FlightLaunchQueryDto, FlightLaunchQuery>();

            CreateMap<LaunchDetailsDto, LaunchDetails>();

            CreateMap<FlightLaunchInformationDto, FlightLaunchInformation>();
            CreateMap<RocketDetailsDto, RocketDetails>();
            CreateMap<ExternalLinksDto, ExternalLinks>();
            CreateMap<RocketFirstStageDto, RocketFirstStage>();
            CreateMap<RocketSecondStageDto, RocketSecondStage>();
            CreateMap<StagePayloadDto, StagePayload>();
            CreateMap<StageCoreDto, StageCore>();
        }
    }
}
