using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace API.Models
{
    public class Patient
    {
        [Key]
        public Guid PatientId { get; set; }
        [Required]
        public string? PatientName { get; set; }

        [Required]
        [DisplayName("Disease Information")]
        public Guid DiseaseInformation_Id { get; set; }
        [ForeignKey("DiseaseInformation_Id")]
        public virtual DiseaseInformation? DiseaseInformation { get; set; }

        public bool Epilepsy { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem>? DiseaseInformationSelectList { get; set; }
        [NotMapped]
        public List<NCD>? NCDs { get; set; }
        [NotMapped]
        public List<Allergies>? Allergies { get; set; }
    }
}
