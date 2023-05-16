using SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse;

namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class StagePayload
    {
        public bool IsReused { get; set; }
        public List<string> Customers { get; set; }
        public string Nationality { get; set; }
        public string Manufacturer { get; set; }
        public string PayloadType { get; set; }
        public double? PayloadMassInKg { get; set; }
        public string Orbit { get; set; }
        public string CapSerial { get; set; }
        public double? MassReturnedInKgs { get; set; }
        public int? FlightTimeInSeconds { get; set; }
        public string CargoManifest { get; set; }
    }
}
