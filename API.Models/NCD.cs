using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class NCD
    {
        [Key]
        public Guid NCDID { get; set; }
        public string? NCDName { get; set; }
    }
}
