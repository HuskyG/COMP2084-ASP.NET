﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class ActivityType
    {
        public int ActivityTypeId { get; set; }

        [Required]
        public string TypeName { get; set; }

        //Add child ref (1 Type => Many Activities)
        public List<Activity> Activities { get; set; }
    }
}
