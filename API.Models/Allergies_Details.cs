using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class Allergies_Details
    {
        [Key]
        public Guid AllergiesDetailsId { get; set; }
        public Guid PatientId { get; set; }
        public Guid AllergiesID { get; set; }
    }
}
