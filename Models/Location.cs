using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class Location
    {
        [Range(1, 999999)]
        public int LocationId { get; set; }

        [Required]
        [MaxLength(25)]
        public string ProvinceName { get; set; }

        [Required]
        [MaxLength(25)]
        public string City { get; set; }

        [Required]
        [MaxLength(25)]
        public string District { get; set; }

        [Required]
        [MaxLength(50)]
        public string StreetName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LocationName { get; set; }

        //Add child ref (1 location => Many Activities)
        public List<Activity> Activities { get; set; }
    }
}
