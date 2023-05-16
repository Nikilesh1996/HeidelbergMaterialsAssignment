
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceXSearchWebApp.Common.Abstractions.Models;
using SpaceXSearchWebApp.Test.Common.BizzLogic;
using SpaceXSearchWebApp.Test.Common.Drivers;
using TechTalk.SpecFlow;

namespace SpaceXSearchWebApp.Component_Tests.Scenarios.StepDefinitions
{
    [Binding, Scope(Feature = "FlightLaunchesController")]
    public class FlightLaunchControllerSteps
    {
        private readonly ApiTestInitializer _testInitializer;
        private readonly ScenarioContext _scenarioContext;
        private readonly IFlightLaunchesDriver _flightLaunchesDriver;

        #region Scenario context keys
        private const string ALL_LAUNCHES = "allLaunches";

        private const string FLIGHT_NUMBER = "flightNumber";
        private const string FLIGHT_LAUNCH_DETAILS = "flightLaunchDetails";

        private const string FLIGHT_QUERY = "flightQuery";
        private const string FILTERED_FLIGHTS = "filteredFlights";

        private const string ERROR_MESSAGE = "errorMessage";
        #endregion

        public FlightLaunchControllerSteps(ScenarioContext scenarioContext, TestContext testContext)
        {
            _scenarioContext = scenarioContext; 
            _testInitializer = new ApiTestInitializer(testContext);
            _flightLaunchesDriver = new FlightLaunchesDriver(_testInitializer.FlightLaunchesControllerBaseUri);
        }

        #region IT_FlightLaunches_Controller_Get_All_Launches_Flow
        [Given(@"Valid parameters")]
        public void GivenValidParameters() { }

        [When(@"Launches current and past launch details are requested")]
        public void WhenLaunchesCurrentAndPastLaunchDetailsAreRequested()
        {
            var allLaunches = _flightLaunchesDriver.GetAllLaunchDetails();
            _scenarioContext.Add(ALL_LAUNCHES, allLaunches);
        }

        [Then(@"Current and past launch details are retrieved")]
        public void ThenCurrentAndPastLaunchDetailsAreRetrieved()
        {
            var allLaunches = _scenarioContext.Get<IEnumerable<LaunchDetails>>(ALL_LAUNCHES);
            Assert.IsNotNull(allLaunches);
            Assert.IsTrue(allLaunches.Any());            
        }
        #endregion

        #region IT_FlightLaunches_Controller_Get_Launch_By_Id_Flow
        [Given(@"Valid flight number")]
        public void GivenValidFlightNumber()
        {
            _scenarioContext.Add(FLIGHT_NUMBER, 2);
        }

        [When(@"Requested flight launch details are asked")]
        public void WhenRequestedFlightLaunchDetailsAreAsked()
        {
            var flightNumber = _scenarioContext.Get<int>(FLIGHT_NUMBER);
            var launchDetails = _flightLaunchesDriver.GetFlightLaunchInformation(flightNumber);

            _scenarioContext.Add(FLIGHT_LAUNCH_DETAILS, launchDetails);
        }

        [Then(@"Flight launch details must be retrieved")]
        public void ThenFlightLaunchDetailsMustBeRetrieved()
        {
            var requestedFlightNumber = _scenarioContext.Get<int>(FLIGHT_NUMBER);
            var flightLaunchDetails = _scenarioContext.Get<FlightLaunchInformation>(FLIGHT_LAUNCH_DETAILS);

            Assert.IsNotNull(flightLaunchDetails);
            Assert.AreEqual(requestedFlightNumber, flightLaunchDetails.FlightNumber);
        }

        #endregion

        #region IT_FlightLaunches_Controller_Get_Launch_By_Id_Flow_With_Invalid_Id
        [Given(@"Negative invalid flight number")]
        public void GivenNegativeInvalidFlightNumber()
        {
            _scenarioContext.Add(FLIGHT_NUMBER, -1);
        }

        [When(@"Requested flight launch details are fetched")]
        public void WhenRequestedFlightLaunchDetailsAreFetched()
        {
            var flightNumber = _scenarioContext.Get<int>(FLIGHT_NUMBER);

            try
            {
                var launchDetails = _flightLaunchesDriver.GetFlightLaunchInformation(flightNumber);
            }
            catch(Exception ex)
            {
                _scenarioContext.Add(ERROR_MESSAGE, ex.Message);
            }

        }

        [Then(@"Valid error message is returned")]
        public void ThenValidErrorMessageIsReturned()
        {
            var errorMessage = _scenarioContext.Get<string>(ERROR_MESSAGE);
            Assert.IsNotNull(errorMessage);
            Assert.IsTrue(errorMessage.Length > 0);
        }

        #endregion

        #region IT_FlightLaunches_Controller_Get_Launches_Within_Date_Range
        [Given(@"Valid date range")]
        public void GivenValidDateRange()
        {
            var query = new FlightLaunchQuery
            {
                EndDateUtc = DateTime.UtcNow,
                StartDateUtc = new DateTime(2010, 1, 1)
            };

            _scenarioContext.Add(FLIGHT_QUERY, query);      
        }

        [When(@"Requested flight launch details are asked within specified date range")]
        public void WhenRequestedFlightLaunchDetailsAreAskedWithinSpecifiedDateRange()
        {
            var query = _scenarioContext.Get<FlightLaunchQuery>(FLIGHT_QUERY);
            var launches = _flightLaunchesDriver.GetLaunchDetails(query);

            _scenarioContext.Add(FILTERED_FLIGHTS, launches);
        }

        [Then(@"Flight launch details must be retrieved for specified date range")]
        public void ThenFlightLaunchDetailsMustBeRetrievedForSpecifiedDateRange()
        {
            var query = _scenarioContext.Get<FlightLaunchQuery>(FLIGHT_QUERY);
           
            var filteredLaunches = _scenarioContext.Get<IEnumerable<LaunchDetails>>(FILTERED_FLIGHTS);
            Assert.IsNotNull(filteredLaunches);
            Assert.IsTrue(filteredLaunches.Any());

            var (minLaunchDate, maxLaunchDate) = (filteredLaunches.Min(x => x.LaunchDateUtc),
                                                  filteredLaunches.Max(x => x.LaunchDateUtc));

            Assert.IsTrue(query.StartDateUtc.Value <= minLaunchDate);
            Assert.IsTrue(query.EndDateUtc.Value >= maxLaunchDate);

        }

        #endregion

        #region IT_FlightLaunches_Controller_Get_Launches_Within_Date_Range_With_Invalid_Params
        [Given(@"Invalid date range")]
        public void GivenInvalidDateRange()
        {
            var query = new FlightLaunchQuery
            {
                EndDateUtc = new DateTime(2010, 1, 1),
                StartDateUtc = DateTime.UtcNow
            };

            _scenarioContext.Add(FLIGHT_QUERY, query);
        }

        [Then(@"There should be no flight launches returned")]
        public void ThenThereShouldBeNoFlightLaunchesReturned()
        {
            var filteredLaunches = _scenarioContext.Get<IEnumerable<LaunchDetails>>(FILTERED_FLIGHTS);

            Assert.IsNotNull(filteredLaunches);
            Assert.IsTrue(!filteredLaunches.Any());
        }

        #endregion

        #region IT_FlightLaunches_Controller_Get_Launches_Within_Date_Range_With_No_Start_And_End_Date
        [Given(@"No start and end dates")]
        public void GivenNoStartAndEndDates()
        {
            var query = new FlightLaunchQuery
            {
                EndDateUtc = null,
                StartDateUtc = null
            };

            _scenarioContext.Add(FLIGHT_QUERY, query);
        }

        #endregion
    }
}
