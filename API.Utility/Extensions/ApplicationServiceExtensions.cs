using API.DataAccess.Data;
using API.DataAccess.Repository;
using API.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Utility.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
             IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddCors();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IDiseaseRepository, DiseaseRepository>();
            services.AddScoped<INcdRepository, NcdRepository>();
            services.AddScoped<IAllergiesRepository, AllergiesRepository>();

            return services;
        }
    }
}
