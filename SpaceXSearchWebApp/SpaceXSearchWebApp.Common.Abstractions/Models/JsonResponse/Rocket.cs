namespace SpaceXSearchWebApp.Common.Abstractions.Models.JsonResponse
{
    public class Rocket
    {
        public string rocket_id { get; set; }
        public string rocket_name { get; set; }
        public string rocket_type { get; set; }
        public FirstStage first_stage { get; set; }
        public SecondStage second_stage { get; set; }
        public Fairings fairings { get; set; }
    }
}
