

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace SpaceXSearchWebApp.Test.Common.BizzLogic
{
    public class ApiTestInitializer
    {
        public Uri FlightLaunchesControllerBaseUri { get; private set; }

        public ApiTestInitializer(TestContext testContext)
        {
            InitializeMembers(testContext);
        }

        private void InitializeMembers(TestContext testContext)
        {
            FlightLaunchesControllerBaseUri = new Uri(testContext.GetValueIfExists("BASE_URL"));
        }
    }
}