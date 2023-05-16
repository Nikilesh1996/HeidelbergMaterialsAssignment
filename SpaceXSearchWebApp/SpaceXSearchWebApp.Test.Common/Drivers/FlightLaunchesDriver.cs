using AutoMapper;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Mappings;
using SpaceXSearchWebApp.Common.Models;
using SpaceXSearchWebApp.Test.Common.DSL;

namespace SpaceXSearchWebApp.Test.Common.Drivers
{
    public class FlightLaunchesDriver : IFlightLaunchesDriver
    {
        private readonly Uri _baseUri;
        public FlightLaunchesDriver(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        public IEnumerable<LaunchDetails> GetAllLaunchDetails()
        {
            var httpClientRequest = new HttpClient { BaseAddress = _baseUri };
            var flightLaunchesDsl = new FlightLaunchesDSL(httpClientRequest);

            var allLaunches = flightLaunchesDsl.GetAllLaunches();
            var mapper = GetMapper<DtoToDomainModelMapper>();

            return mapper.Map<IEnumerable<LaunchDetails>>(allLaunches);
        }

        public FlightLaunchInformation GetFlightLaunchInformation(int flightNumber)
        {
            var httpClientRequest = new HttpClient { BaseAddress = _baseUri };
            var flightLaunchesDsl = new FlightLaunchesDSL(httpClientRequest);

            var launchDetails = flightLaunchesDsl.GetLaunchDetails(flightNumber);
            var mapper = GetMapper<DtoToDomainModelMapper>();

            return mapper.Map<FlightLaunchInformation>(launchDetails);
        }

        public IEnumerable<LaunchDetails> GetLaunchDetails(FlightLaunchQuery query)
        {
            var domainToDtoMapper = GetMapper<DomainModelToDtoMapper>();
            var queryDto = domainToDtoMapper.Map<FlightLaunchQueryDto>(query);

            var httpClientRequest = new HttpClient { BaseAddress = _baseUri };
            var flightLaunchesDsl = new FlightLaunchesDSL(httpClientRequest);

            var allLaunches = flightLaunchesDsl.GetLaunches(queryDto);
            var dtoToDomainMapper = GetMapper<DtoToDomainModelMapper>();

            return dtoToDomainMapper.Map<IEnumerable<LaunchDetails>>(allLaunches);
        }


        #region Helpers
        private IMapper GetMapper<T>() where T : Profile, new()
        {
            var profile = new T();
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile(profile));
            return mapperConfiguration.CreateMapper();
        }
        #endregion
    }
}
