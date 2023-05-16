using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace SpaceXSearchWebApp.Test.Common.BizzLogic
{
    public static class RunsettingsVariablesValueExtractor
    {
        public static string GetValueIfExists(this TestContext testContext, string variable)
        {
            var value = testContext?.Properties[variable].ToString();

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"{variable} is not set or empty");
            }

            return value;
        }
    }
}
