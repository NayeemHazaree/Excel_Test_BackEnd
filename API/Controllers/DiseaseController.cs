using API.DataAccess.Repository.IRepository;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DiseaseController : BaseApiController
    {
        private readonly IDiseaseRepository _diseaseRepo;

        public DiseaseController(IDiseaseRepository diseaseRepo)
        {
            _diseaseRepo = diseaseRepo;
        }

        [HttpGet("GetAllDiseaseInformation")]
        public async Task<List<DiseaseInformation>> GetAllDiseaseInformation()
        {
            return await _diseaseRepo.GetAllDiseaseInformation();
        }

        [HttpGet("GetAllNCDs")]
        public async Task<List<NCD>> GetAllNCDs()
        {
            return await _diseaseRepo.GetAllNCDs();
        }

        [HttpGet("GetAllAllergies")]
        public async Task<List<Allergies>> GetAllAllergies()
        {
            return await _diseaseRepo.GetAllAllergies();
        }

        [HttpGet("GetNCD_DetailsByPatientId")]
        public async Task<List<NCD_Details>> GetNCD_DetailsByPatientId(Guid Id)
        {
            return await _diseaseRepo.GetNCD_DetailsByPatientId(Id);
        }

        [HttpGet("GetAllergies_DetailsByPatientId")]
        public async Task<List<Allergies_Details>> GetAllergies_DetailsByPatientId(Guid Id)
        {
            return await _diseaseRepo.GetAllergies_DetailsByPatientId(Id);
        }
    }
}
