using EmployeeMaintenance.Domain.Contexts;
using EmployeeMaintenance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaintenance.Domain.Commands.Employees
{
    public class DeleteEmployee : DomainCommand<bool>
    {
        public int PersonId { get; set; }

        public DeleteEmployee( DomainContext domainContext) : base(domainContext)
        {

        }

        protected override Task<bool> ExecuteInternal()
        {
            var repo = Context.Repository;

            // Lastly delete board
            repo.DeleteWhere<Employee>(i => i.PersonId == PersonId);
            repo.DeleteWhere<Person>(i => i.PersonId == PersonId);
            repo.Commit();

            return Task.FromResult(true);
        }

        protected override bool VerifyStateInternal()
        {
            return true;
        }
    }
}
