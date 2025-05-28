using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eg_api.Models
{
    public class Satellite
    {
        [Key]
        public int Sat_id { get; set; }
        [Required]
        public string Sat_ref { get; set; }
    }
}