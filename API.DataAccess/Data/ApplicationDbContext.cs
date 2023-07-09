using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<NCD> NCD { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<Allergies_Details> Allergies_Details { get; set; }
        
    }
}
