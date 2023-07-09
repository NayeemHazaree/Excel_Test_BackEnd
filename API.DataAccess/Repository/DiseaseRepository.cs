using API.DataAccess.Data;
using API.DataAccess.Repository.IRepository;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repository
{
    public class DiseaseRepository : IDiseaseRepository
    {
        private readonly ApplicationDbContext _db;
        public DiseaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Allergies>> GetAllAllergies()
        {
            return await _db.Allergies.ToListAsync();
        }

        public async Task<List<DiseaseInformation>> GetAllDiseaseInformation()
        {
            return await _db.DiseaseInformation.ToListAsync();
        }

        public async Task<List<Allergies_Details>> GetAllergies_DetailsByPatientId(Guid Id)
        {
            return await _db.Allergies_Details.Where(x => x.PatientId == Id).ToListAsync();
        }

        public async Task<List<NCD>> GetAllNCDs()
        {
            return await _db.NCD.ToListAsync();
        }

        public async Task<List<NCD_Details>> GetNCD_DetailsByPatientId(Guid Id)
        {
            return await _db.NCD_Details.Where(x => x.PatientId == Id).ToListAsync();
        }
    }
}
