
using RestEase;
using SpaceXSearchWebApp.Common.Models;

namespace SpaceXSearchWebApp.Test.Common.DSL
{    
    public class FlightLaunchesDSL
    {
        private readonly IFlightLaunchesInformationProvider _flightLaunchesInformationProvider;

        public FlightLaunchesDSL(HttpClient httpRequest)
        {
            _flightLaunchesInformationProvider = RestClient.For<IFlightLaunchesInformationProvider>(httpRequest);
        }

        public IEnumerable<LaunchDetailsDto> GetAllLaunches()
        {
            return _flightLaunchesInformationProvider.GetAllLaunches()
                                                     .GetAwaiter()
                                                     .GetResult();
        }

        public IEnumerable<LaunchDetailsDto> GetLaunches(FlightLaunchQueryDto query)
        {
            return _flightLaunchesInformationProvider.GetLaunches(query)
                                                     .GetAwaiter()
                                                     .GetResult();
        }

        public FlightLaunchInformationDto GetLaunchDetails(int flightNumber)
        {
            return _flightLaunchesInformationProvider.GetLaunchDetails(flightNumber)
                                                     .GetAwaiter()
                                                     .GetResult();
        }
    }

    [BasePath("api/flightLaunches")]
    public interface IFlightLaunchesInformationProvider
    {
        [Get("allLaunches")]
        public Task<IEnumerable<LaunchDetailsDto>> GetAllLaunches();

        [Get("launch/{flightNumber}")]
        public Task<FlightLaunchInformationDto> GetLaunchDetails([Path] int flightNumber);

        [Post("launches")]
        public Task<IEnumerable<LaunchDetailsDto>> GetLaunches([Body] FlightLaunchQueryDto flightLaunchQueryDto);

    }
}
