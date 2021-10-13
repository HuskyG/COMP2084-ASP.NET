using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class TripSchedule
    {
        public int TripId { get; set; }

        public string TripName { get; set; }

        public decimal Duration { get; set; }

        public string UserId { get; set; }

        //Add child ref to Daily schedule
        
    }
}
