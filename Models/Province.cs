using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chravel.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }

        [Required]
        public string ProvinceName { get; set; }
    }
}
