using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class Activity
    {
        [Range(1,999999)]
        public int ActivityId { get; set; }

        [Required]
        [MaxLength(20)]
        public string ActivityName { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        [Range(1, 99999)]
        public decimal AveragePricePerPerson { get; set; }

        [Required]
        [Range(1, 100)]
        public int ActivityTypeId { get; set; }

        [Required]
        [Range(1, 999999)]
        public int LocactionId { get; set; }


        //Add parent ref
        public ActivityType ActivityType { get; set; }

        public Location Location { get; set; }

        //Add child ref (1 Activity => Many Daily Schedule)
        public List<DailySchedule> DailySchedules { get; set; }

    }
}
