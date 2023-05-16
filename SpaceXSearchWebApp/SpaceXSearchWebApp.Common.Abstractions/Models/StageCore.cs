namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class StageCore
    {
        public string CoreSerial { get; set; }
        public bool? HasGridFins { get; set; }
        public bool? HasLegs { get; set; }
        public bool? IsReused { get; set; }
        public bool? IsLandingSuccessful { get; set; }
        public string LandingType { get; set; }
        public string LandingVehicle { get; set; }
    }
}
