using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeMaintenance.Domain.Repositories
{
    public interface IEntityRepositoryFactory
    {
        IEntityRepository CreateRepository();
    }
}
