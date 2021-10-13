using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class Activities
    {
        public int ActivityId { get; set; }

        [Required]
        public string ActivityName { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public decimal AveragePricePerPerson { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public int LocactionId { get; set; }


        //Add parent ref
        public Type Type { get; set; }

        public Location Location { get; set; }

        //Add child ref (1 Activity => Many Daily Schedule)
        public List<DailySchedule> DailySchedules { get; set; }

    }
}
