using API.DataAccess.Data;
using API.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DataAccess.Repository
{
    public class AllergiesRepository : IAllergiesRepository
    {
        private readonly ApplicationDbContext _db;
        public AllergiesRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task RemoveAll(Guid patientId)
        {
            var deleteRecords = await _db.Allergies_Details.Where(x => x.PatientId == patientId).ToListAsync();
            foreach (var deleteRecord in deleteRecords)
            {
                _db.Remove(deleteRecord);
            }
        }
    }
}
