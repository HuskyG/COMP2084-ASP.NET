using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class District
    {
        public int DistrictId { get; set; }

        [Required]
        public string DistrictName { get; set; }
    }
}
