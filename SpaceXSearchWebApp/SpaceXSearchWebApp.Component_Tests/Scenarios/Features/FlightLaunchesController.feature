Feature: FlightLaunchesController

A short summary of the feature

@ComponentTests
Scenario: IT_FlightLaunches_Controller_Get_All_Launches_Flow
	Given Valid parameters
	When Launches current and past launch details are requested
	Then Current and past launch details are retrieved


@ComponentTests
Scenario: IT_FlightLaunches_Controller_Get_Launch_By_Id_Flow
	Given Valid flight number
	When Requested flight launch details are asked
	Then Flight launch details must be retrieved

@ComponentTests
Scenario: IT_FlightLaunches_Controller_Get_Launch_By_Id_Flow_With_Invalid_Id
	Given Negative invalid flight number
	When Requested flight launch details are fetched
	Then Valid error message is returned


@ComponentTests
Scenario: IT_FlightLaunches_Controller_Get_Launches_Within_Date_Range
	Given Valid date range
	When Requested flight launch details are asked within specified date range
	Then Flight launch details must be retrieved for specified date range


@ComponentTests
Scenario: IT_FlightLaunches_Controller_Get_Launches_Within_Date_Range_With_Invalid_Params
	Given Invalid date range
	When Requested flight launch details are asked within specified date range
	Then There should be no flight launches returned


@ComponentTests
Scenario: IT_FlightLaunches_Controller_Get_Launches_Within_Date_Range_With_No_Start_And_End_Date
	Given No start and end dates
	When Requested flight launch details are asked within specified date range
	Then There should be no flight launches returned
