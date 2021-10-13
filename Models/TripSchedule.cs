using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class TripSchedule
    {
        [Range(1, 999999)]
        public int TripScheduleId { get; set; }

        [Required]
        [MaxLength(10)]
        public string TripName { get; set; }

        [Required]
        [Range(0, 9999)]
        public decimal Duration { get; set; }

        [Required]
        public string UserId { get; set; }

        //Add child ref of Daily schedule (1 TripShedule => Many Daily Schedules)
        public List<DailySchedule> DailySchedules { get; set; }

    }
}
