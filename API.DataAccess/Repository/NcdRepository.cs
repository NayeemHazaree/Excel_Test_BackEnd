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
    public class NcdRepository : INcdRepository
    {
        private readonly ApplicationDbContext _db;
        public NcdRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task RemoveAll(Guid patientId)
        {
            var DeleteRecords = await _db.NCD_Details.Where(x => x.PatientId == patientId).ToListAsync();
            foreach (var record in DeleteRecords)
            {
                _db.Remove(record);
            }
        }
    }
}
