namespace SpaceXSearchWebApp.Common.Models
{
    public class StageCoreDto
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
