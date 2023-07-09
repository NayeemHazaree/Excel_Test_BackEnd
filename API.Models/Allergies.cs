using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Allergies
    {
        [Key]
        public Guid AllergiesID { get; set; }
        public string? AllergiesName { get; set; }
    }
}
