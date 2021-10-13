using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required]
        public string ProvinceName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string LocationName { get; set; }

        //Add child ref (1 location => Many Activities)
        public List<Activity> Activities { get; set; }
    }
}
