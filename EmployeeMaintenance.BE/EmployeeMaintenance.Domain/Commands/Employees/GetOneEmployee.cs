using EmployeeMaintenance.Domain.Contexts;
using EmployeeMaintenance.Domain.Entities;
using EmployeeMaintenance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaintenance.Domain.Commands.Employees
{
	public sealed class GetOneEmployee : DomainCommand<PersonEmployeeDto>
	{

		public int EmployeeId { get; set; }

		public GetOneEmployee(DomainContext domainContext)
		   : base(domainContext)
		{

		}

		protected override bool VerifyStateInternal()
		{
			return true;
		}

		protected override Task<PersonEmployeeDto> ExecuteInternal()
		{
			var repo = Context.Repository;
			var employee = repo.All<Employee>().First(i => i.EmployeeId == EmployeeId);
			var person = repo.All<Person>().First(i => i.PersonId == employee.PersonId);

			return Task.FromResult(new PersonEmployeeDto
			{
				BirthDate = person.BirthDate,
				EmployedDate = employee.EmployedDate,
				LastName = person.LastName,
				FirstName = person.FirstName,
				PersonId = person.PersonId,
				EmployeeId = employee.EmployeeId,
				EmployeeNum = employee.EmployeeNum,
				TerminatedDate = employee.TerminatedDate,
			});
		}
	}
}
