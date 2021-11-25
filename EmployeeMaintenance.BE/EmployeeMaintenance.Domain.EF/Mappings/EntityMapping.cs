using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeMaintenance.Domain.EF.Mappings
{
    public abstract class EntityMapping<T> : IEntityTypeConfiguration<T>, IMappingConfig where T : class
    {
        public abstract void Configure(EntityTypeBuilder<T> builder);

        public void Register(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<T>());
        }
    }
}
