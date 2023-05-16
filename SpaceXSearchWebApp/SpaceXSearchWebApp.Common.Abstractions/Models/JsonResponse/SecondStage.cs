namespace SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse
{
    public class SecondStage
    {
        public int? block { get; set; }
        public List<Payload> payloads { get; set; }
    }
}
