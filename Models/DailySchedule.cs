using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class DailySchedule
    {
        public int DailyScheduleId { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public decimal Duration { get; set; }

        [Required]
        public int ActivityId { get; set; }

        [Required]
        public int TripScheduleId { get; set; }

        //Add Parent ref (1 TripSchedule => Many Daily Schedules)
        public TripSchedule TripSchedule { get; set; }

        //Add Parent ref (1 Activity => Many Daily Schedules)
        public Activity Activities { get; set; }


    }
}
