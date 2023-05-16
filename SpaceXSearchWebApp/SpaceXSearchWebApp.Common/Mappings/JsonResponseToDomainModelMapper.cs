using AutoMapper;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse;

namespace SpaceXSearchWebApp.Common.Mappings
{
    public class JsonResponseToDomainModelMapper : Profile
    {
        public JsonResponseToDomainModelMapper()
        {
            #region Launch summary mappings
            CreateMap<LaunchInfo, LaunchDetails>()
                .ForMember(x => x.FlightNumber, opt => opt.MapFrom(y => y.flight_number))
                .ForMember(x => x.RocketName, opt => opt.MapFrom(y => y.rocket.rocket_name))
                .ForMember(x => x.RocketType, opt => opt.MapFrom(y => y.rocket.rocket_type))
                .ForMember(x => x.IsLaunchDateToBeDecided, opt => opt.MapFrom(y => y.tbd))
                .ForMember(x => x.LaunchDateUtc, opt => opt.MapFrom(y => y.launch_date_utc))
                .ForMember(x => x.MissionName, opt => opt.MapFrom(y => y.mission_name));
            #endregion

            #region Launch details mappings
            CreateMap<LaunchInfo, FlightLaunchInformation>()
                .ForMember(x => x.FlightNumber, opt => opt.MapFrom(y => y.flight_number))
                .ForMember(x => x.LaunchSuccess, opt => opt.MapFrom(y => y.launch_success))
                .ForMember(x => x.MissionName, opt => opt.MapFrom(y => y.mission_name))
                .ForMember(x => x.IsLaunchDateToBeDecided, opt => opt.MapFrom(y => y.tbd))
                .ForMember(x => x.LaunchDateUtc, opt => opt.MapFrom(y => y.launch_date_utc))
                .ForMember(x => x.LaunchSite, opt => opt.MapFrom(y => y.launch_site.site_name_long))
                .ForMember(x => x.Details, opt => opt.MapFrom(y => y.details))
                .ForMember(x => x.Links, 
                            opt => opt.MapFrom(
                                (src, dest, _, context) => context.Mapper.Map<ExternalLinks>(src.links)))
                .ForMember(x => x.RocketDetails, 
                            opt => opt.MapFrom(
                                (src, dest, _, context) => context.Mapper.Map<RocketDetails>(src.rocket)));

            CreateMap<Rocket, RocketDetails>()
                .ForMember(x => x.RocketName, opt => opt.MapFrom(y => y.rocket_name))
                .ForMember(x => x.RocketType, opt => opt.MapFrom(y => y.rocket_type))
                .ForMember(x => x.FirstStage,
                            opt => opt.MapFrom(
                                (src, dest, _, context) => context.Mapper.Map<RocketFirstStage>(src.first_stage)))
                .ForMember(x => x.SecondStage, 
                            opt => opt.MapFrom(
                                (src, dest, _, context) => context.Mapper.Map<RocketSecondStage>(src.second_stage)));

            #region First stage mappings
            CreateMap<FirstStage, RocketFirstStage>()
                .ForMember(x => x.Cores, opt => opt.MapFrom((src, dest, _, context) => context.Mapper.Map<List<StageCore>>(src.cores)));

            CreateMap<Core, StageCore>()
                .ForMember(x => x.CoreSerial, opt => opt.MapFrom(y => y.core_serial))
                .ForMember(x => x.HasGridFins, opt => opt.MapFrom(y => y.gridfins))
                .ForMember(x => x.HasLegs, opt => opt.MapFrom(y => y.legs))
                .ForMember(x => x.IsReused, opt => opt.MapFrom(y => y.reused))
                .ForMember(x => x.IsLandingSuccessful, opt => opt.MapFrom(y => y.land_success))
                .ForMember(x => x.LandingType, opt => opt.MapFrom(y => y.landing_type))
                .ForMember(x => x.LandingVehicle, opt => opt.MapFrom(y => y.landing_vehicle));
            #endregion


            #region Second stage mappings
            CreateMap<SecondStage, RocketSecondStage>()
                .ForMember(x => x.Payloads, opt => opt.MapFrom((src, dest, _, context) => context.Mapper.Map<List<StagePayload>>(src.payloads)));

            CreateMap<Payload, StagePayload>()
                .ForMember(x => x.IsReused, opt => opt.MapFrom(y => y.reused))
                .ForMember(x => x.Customers, opt => opt.MapFrom(y => y.customers))
                .ForMember(x => x.Nationality, opt => opt.MapFrom(y => y.nationality))
                .ForMember(x => x.Manufacturer, opt => opt.MapFrom(y => y.manufacturer))
                .ForMember(x => x.PayloadType, opt => opt.MapFrom(y => y.payload_type))
                .ForMember(x => x.PayloadMassInKg, opt => opt.MapFrom(y => y.payload_mass_kg))
                .ForMember(x => x.Orbit, opt => opt.MapFrom(y => y.orbit))
                .ForMember(x => x.CapSerial, opt => opt.MapFrom(y => y.cap_serial))
                .ForMember(x => x.MassReturnedInKgs, opt => opt.MapFrom(y => y.mass_returned_kg))
                .ForMember(x => x.FlightTimeInSeconds, opt => opt.MapFrom(y => y.flight_time_sec))
                .ForMember(x => x.CargoManifest, opt => opt.MapFrom(y => y.cargo_manifest));
            #endregion

            CreateMap<Links, ExternalLinks>()
                .ForMember(x => x.MissionPatch, opt => opt.MapFrom(y => y.mission_patch_small))
                .ForMember(x => x.ArticleLink, opt => opt.MapFrom(y => y.article_link))
                .ForMember(x => x.WikipediaLink, opt => opt.MapFrom(y => y.wikipedia))
                .ForMember(x => x.VideoLink, opt => opt.MapFrom(y => y.video_link));
            #endregion

        }
    }
}
