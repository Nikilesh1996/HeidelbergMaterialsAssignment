namespace SpaceXSearchWebApp.Common.Abstractions.Models
{
    public class SpaceXApiConfiguration
    {
        public string BaseUrl { get; set; }
        public string BaseVersion { get; set; }

        public string VersionedUrl { get => $"{BaseUrl}/{BaseVersion}"; }
    }
}
