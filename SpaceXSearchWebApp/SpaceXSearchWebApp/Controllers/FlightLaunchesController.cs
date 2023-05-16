using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Common.Contracts;
using SpaceXSearchWebApp.Common.Mappings;
using SpaceXSearchWebApp.Common.Models;

namespace SpaceXSearchWebApp.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class FlightLaunchesController : ControllerBase
    {
        private readonly ILogger<FlightLaunchesController> _logger;
        private readonly ILaunchUtilityService _launchUtilityService;
        private readonly IApiUtils _apiUtils;
        private readonly IMapper _domainModelToDtoMapper, _dtoToDomainModelMapper;

        public FlightLaunchesController(ILogger<FlightLaunchesController> logger,
            ILaunchUtilityService launchUtilityService,
            IApiUtils apiUtils)
        {
            _apiUtils = apiUtils;
            _logger = logger;
            _launchUtilityService = launchUtilityService;

            _domainModelToDtoMapper = _apiUtils.GetMapper<DomainModelToDtoMapper>();
            _dtoToDomainModelMapper = _apiUtils.GetMapper<DtoToDomainModelMapper>();
        }

        [HttpGet(Name = "isAlive")]
        public IActionResult IsAlive()
        {
            return Ok($"{nameof(FlightLaunchesController)} is alive!");
        }

        [HttpGet]
        [Route("allLaunches")]
        public async Task<ActionResult<IEnumerable<LaunchDetailsDto>>> GetAllLaunches()
        {
            try
            {
                var launches = await _launchUtilityService.GetAllLaunches();
                var launchesDto = _domainModelToDtoMapper.Map<List<LaunchDetailsDto>>(launches);

                _logger.LogInformation("Retrieved all launch details successfully!");
                return Ok(launchesDto.ToList());
            } 
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("launch/{flightNumber}")]
        public async Task<ActionResult<FlightLaunchInformationDto>> GetLaunches([FromRoute] int flightNumber)
        {
            try
            {
                var launchDetails = await _launchUtilityService.GetLaunchDetails(flightNumber);
                var launchesDetailsDto = _domainModelToDtoMapper.Map<FlightLaunchInformationDto>(launchDetails);

                _logger.LogInformation("Retrieved all launch details for flight successfully!");
                return Ok(launchesDetailsDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("launches")]
        public async Task<ActionResult<IEnumerable<LaunchDetailsDto>>> GetLaunches(
                                    [FromBody] FlightLaunchQueryDto flightLaunchQueryDto)
        {
            try
            {
                var flightLaunchQuery = _dtoToDomainModelMapper.Map<FlightLaunchQuery>(flightLaunchQueryDto);

                var launches = await _launchUtilityService.GetLaunches(flightLaunchQuery);
                var launchesDto = _domainModelToDtoMapper.Map<List<LaunchDetailsDto>>(launches);

                _logger.LogInformation($"Retrieved launch details from {flightLaunchQuery.StartDateUtc} " +
                                       $"to {flightLaunchQuery.EndDateUtc} successfully!");

                return Ok(launchesDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
