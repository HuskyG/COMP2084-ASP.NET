using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class ActivityType
    {
        [Range(1, 100)]
        public int ActivityTypeId { get; set; }

        [Required]
        [MaxLength(10)]
        public string TypeName { get; set; }

        //Add child ref (1 Type => Many Activities)
        public List<Activity> Activities { get; set; }
    }
}
