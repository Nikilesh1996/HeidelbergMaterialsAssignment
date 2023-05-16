using System.ComponentModel.DataAnnotations;

namespace SpaceXSearchWebApp.Common.Models
{
    public class FlightLaunchQueryDto
    {        
        public int PageIndex { get; set; }

        [Required]
        public DateTime StartDateUtc { get; set; }

        [Required]
        public DateTime EndDateUtc { get; set; }

    }
}
