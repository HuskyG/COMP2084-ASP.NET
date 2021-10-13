using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class ActivityType
    {
        public int TypeId { get; set; }

        [Required]
        public string TypeName { get; set; }


    }
}
