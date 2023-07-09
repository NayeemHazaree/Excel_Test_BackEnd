using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class DiseaseInformation
    {
        [Key]
        public Guid DiseaseInformationId { get; set; }
        public string? DiseaseInformationName { get; set; }

    }
}
