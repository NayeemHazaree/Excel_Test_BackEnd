using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    public class NCD_Details
    {
        [Key]
        public Guid NCD_Details_Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid NCDID { get; set; }
    }
}
