using SpaceXSearchWebApp.Common.Abstractions.Models;

namespace SpaceXSearchWebApp.Common.Contracts
{
    public interface ILaunchUtilityService
    {
        /// <summary>
        ///     Retieves all launches since the start of SpaceX
        /// </summary>
        /// <returns>
        ///     The list of all launches
        /// </returns>
        Task<IEnumerable<LaunchDetails>> GetAllLaunches();

        /// <summary>
        ///     Retrieves all launches within the date range specified.
        /// </summary>
        /// <param name="launchQuery">
        ///     The query params you need to filter launches upon.
        /// </param>
        /// <returns>
        ///     The list of filtered SpaceX launches.
        /// </returns>
        Task<IEnumerable<LaunchDetails>> GetLaunches(FlightLaunchQuery launchQuery);

        /// <summary>
        ///     Get detailed information of a specific Space X flight
        /// </summary>
        /// <param name="flightNumber">
        ///     The unique flight number that is assigned.
        /// </param>
        /// <returns>
        ///     The flight launch information in detail, for the requrested flight.
        /// </returns>
        Task<FlightLaunchInformation> GetLaunchDetails(int flightNumber);
    }
}
