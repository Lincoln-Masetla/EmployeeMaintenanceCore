using EmployeeMaintenance.Domain.EF.Contexts;
using EmployeeMaintenance.Domain.EF.Repositories;
using EmployeeMaintenance.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeMaintenance.Domain.EF
{
    public static class Setup
    {
        public static void AddDatabaseDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EmployeeMaintenanceDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("EmployeeDbContext");


                options.UseSqlServer(connectionString, (sql) =>
                {
                    sql.EnableRetryOnFailure();
                });
            });

            services.AddScoped<IEntityRepositoryFactory, DbContextEntityRepositoryFactory>();
            services.AddScoped<EmployeeMaintenanceDbContext, EmployeeMaintenanceDbContext>();
            services.AddScoped<IEntityRepository, DbContextRepository>();
        }
    }
}
