using SpaceXSearchWebApp.Common.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXSearchWebApp.Test.Common.Drivers
{
    public interface IFlightLaunchesDriver
    {
        FlightLaunchInformation GetFlightLaunchInformation(int flightNumber);
        IEnumerable<LaunchDetails> GetAllLaunchDetails();
        IEnumerable<LaunchDetails> GetLaunchDetails(FlightLaunchQuery query);
    }
}
