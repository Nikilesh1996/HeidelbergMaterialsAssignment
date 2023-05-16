
using Microsoft.Extensions.Options;
using SpaceXSearchWebApp.BizzLogic.Contracts;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Contracts;
using SpaceXSearchWebApp.Common.Exceptions;
using SpaceXSearchWebApp.Common.Mappings;

namespace SpaceXSearchWebApp.Common.Services
{
    public class LaunchUtilityService : ILaunchUtilityService
    {
        private readonly IApiUtils _apiUtils;
        private readonly SpaceXApiConfiguration _spaceXApiConfiguration;
        private readonly ILogger<LaunchUtilityService> _logger;

        public LaunchUtilityService(IApiUtils apiUtils,
                                    ILogger<LaunchUtilityService> logger,
                                    IOptions<SpaceXApiConfiguration> spaceXApiConfigurationOption)
        {
            _logger = logger;
            _apiUtils = apiUtils;
            _spaceXApiConfiguration = spaceXApiConfigurationOption.Value;
        }

        public async Task<IEnumerable<LaunchDetails>> GetAllLaunches()
        {
            var httpClientRequest = GetBasicHttpClientRequest();

            try
            {
                var flightLaunchesDsl = new SpaceXRemoteWebApiDSL(httpClientRequest);
                var launchInfos = await flightLaunchesDsl.GetAllLaunches();

                if((launchInfos == null) || (!launchInfos.Any()))
                {
                    _logger.LogInformation("No launches found from SpaceX api");
                    return new List<LaunchDetails>();
                }

                _logger.LogInformation($"Found {launchInfos.Count} launches from SpaceX");

                try
                {
                    var jsonToDomainModelMapper = _apiUtils.GetMapper<JsonResponseToDomainModelMapper>();
                    var launchDetails = jsonToDomainModelMapper.Map<List<LaunchDetails>>(launchInfos);

                    return launchDetails;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"From {nameof(GetAllLaunches)} {ex.Message}", ex.StackTrace);
                    throw new AutoMapperMappingException("Something went wrong while mapping json to domain model", ex);
                }
            }
            catch (Exception ex)
            {
                throw new ThirdPartyApiException("Something went wrong while executing space x api.", ex);
            }
        }

        public async Task<FlightLaunchInformation> GetLaunchDetails(int flightNumber)
        {
            var httpClientRequest = GetBasicHttpClientRequest();

            try
            {
                var flightLaunchesDsl = new SpaceXRemoteWebApiDSL(httpClientRequest);
                var launchInfo = await flightLaunchesDsl.GetLaunch(flightNumber);

                if(launchInfo == null)
                {
                    _logger.LogError("Flight number requested is invalid");
                    throw new ArgumentException("Invalid flight requested. Please check flight id.");
                }

                try
                {
                    var jsonToDomainModelMapper = _apiUtils.GetMapper<JsonResponseToDomainModelMapper>();
                    var launchDetail = jsonToDomainModelMapper.Map<FlightLaunchInformation>(launchInfo);

                    return launchDetail;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Mapper error in {nameof(GetLaunchDetails)} {ex.Message} {ex.StackTrace}");
                    throw new AutoMapperMappingException("Something went wrong while mapping json to domain model", ex);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Api error in {nameof(GetLaunchDetails)} {ex.Message} {ex.StackTrace}");
                throw new ThirdPartyApiException("Something went wrong while executing space x api. " +
                                                 "Flight Id requested might be invalid.", ex);
            }
        }

        public async Task<IEnumerable<LaunchDetails>> GetLaunches(FlightLaunchQuery launchQuery)
        {
            if(!IsLaunchQueryValid(launchQuery))
            {
                _logger.LogError($"From Method {GetLaunches}, the given launch query details were found to be invalid.");
                return new List<LaunchDetails>();
            }

            _logger.LogError($"From Method {GetLaunches}, flight launch query validation successful.");
            var httpClientRequest = GetBasicHttpClientRequest();

            try
            {
                var flightLaunchesDsl = new SpaceXRemoteWebApiDSL(httpClientRequest);
                var launchInfos = await flightLaunchesDsl.GetLaunches(launchQuery);

                try
                {
                    var jsonToDomainModelMapper = _apiUtils.GetMapper<JsonResponseToDomainModelMapper>();
                    var launchDetails = jsonToDomainModelMapper.Map<List<LaunchDetails>>(launchInfos);

                    return launchDetails;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Mapper error in {nameof(GetLaunches)} {ex.Message} {ex.StackTrace}");
                    throw new AutoMapperMappingException("Something went wrong while mapping json to domain model", ex);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Api error in {nameof(GetLaunches)} {ex.Message} {ex.StackTrace}");
                throw new ThirdPartyApiException("Something went wrong while executing space x api.", ex);
            }
        }
        

        #region Helpers
        private HttpClient GetBasicHttpClientRequest()
        {
            var baseUri = new Uri(_spaceXApiConfiguration.VersionedUrl);
            return new HttpClient
            {
                BaseAddress = baseUri
            };
        }

        private bool IsLaunchQueryValid(FlightLaunchQuery launchQuery)
        {
            var isQueryValid = true;

            if(!launchQuery.StartDateUtc.HasValue)
            {
                _logger.LogError($"Launch query start date is not specified.");
                isQueryValid = false;
            }

            if(!launchQuery.EndDateUtc.HasValue)
            {
                _logger.LogError($"Launch query end date is not specified.");
                isQueryValid = false;
            }

            if(launchQuery.StartDateUtc > launchQuery.EndDateUtc)
            {
                _logger.LogError($"Start date for launch query {launchQuery.StartDateUtc} " +
                                 $"cannot be more than end date {launchQuery.EndDateUtc}");
                isQueryValid = false;
            }

            return isQueryValid;
        }
        #endregion
    }
}
