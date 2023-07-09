using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repository.IRepository
{
    public interface IDiseaseRepository
    {
        Task<List<DiseaseInformation>> GetAllDiseaseInformation();
        Task<List<NCD>> GetAllNCDs();
        Task<List<Allergies>> GetAllAllergies();
        Task<List<NCD_Details>> GetNCD_DetailsByPatientId(Guid Id);
        Task<List<Allergies_Details>> GetAllergies_DetailsByPatientId(Guid Id);
    }
}
