
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestEase;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse;

namespace SpaceXSearchWebApp.BizzLogic.Contracts
{
    public class SpaceXRemoteWebApiDSL
    {
        private readonly ISpaceXLaunchDetailsProvider _flightLaunchDetailsProvider;        

        public SpaceXRemoteWebApiDSL(HttpClient httpClientRequest)
        {
            _flightLaunchDetailsProvider = RestClient.For<ISpaceXLaunchDetailsProvider>(httpClientRequest);
        }

        public async Task<IList<LaunchInfo>> GetAllLaunches()
        {
            var allLaunches = await _flightLaunchDetailsProvider.GetLaunches();
            return allLaunches;
        }

        public async Task<IList<LaunchInfo>> GetLaunches(FlightLaunchQuery launchQuery)
        {
            const string ACCEPTED_DATE_FORMAT = "yyyy-MM-dd";            
            var (startDate, endDate) = (launchQuery.StartDateUtc, launchQuery.EndDateUtc);
            
            var startDateInRequiredFormat = startDate.Value.ToString(ACCEPTED_DATE_FORMAT);
            var endDateInRequiredFormat = endDate.Value.ToString(ACCEPTED_DATE_FORMAT);

            var result = await _flightLaunchDetailsProvider.GetLaunchesWithinRange(startDateInRequiredFormat, 
                                                                                   endDateInRequiredFormat);

            return result;
        }

        public async Task<LaunchInfo> GetLaunch(int flightNumber)
        {
            var launchDetails = await _flightLaunchDetailsProvider.GetLaunchDetails(flightNumber); 
            return launchDetails;
        }
    }

    public interface ISpaceXLaunchDetailsProvider
    {
        [Get("launches")]
        public Task<List<LaunchInfo>> GetLaunches();

        [Get("launches?start={start}&end={end}")]
        public Task<List<LaunchInfo>> GetLaunchesWithinRange([Path] string start,
                                                             [Path] string end);

        [Get("launches/{flight_number}")]
        public Task<LaunchInfo> GetLaunchDetails([Path] int flight_number);
    }
}
