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
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task UpdatePatient(Patient patient)
        {
            var existingPatient = await _db.Patients.AsNoTracking().FirstOrDefaultAsync(x => x.PatientId == patient.PatientId);
            
            if(existingPatient != null)
            {
                _db.Update(patient);
            }
        }
    }
}
