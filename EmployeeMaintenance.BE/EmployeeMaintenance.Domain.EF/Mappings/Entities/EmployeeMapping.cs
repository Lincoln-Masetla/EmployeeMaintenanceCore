using EmployeeMaintenance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeMaintenance.Domain.EF.Mappings.Entities
{
    public sealed class EmployeeMapping : EntityMapping<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
        }
    }
}
