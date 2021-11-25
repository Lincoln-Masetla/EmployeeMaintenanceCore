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
	public sealed class GetManyEmployees : DomainCommand<PersonEmployeeDtos>
	{
		public bool Employees { get; set; }
		public GetManyEmployees(DomainContext domainContext)
		   : base(domainContext)
		{

		}

		protected override bool VerifyStateInternal()
		{
			return true;
		}

		protected override Task<PersonEmployeeDtos> ExecuteInternal()
		{
			var repo = Context.Repository;
			var employees = repo.All<Employee>();
			var persons = repo.All<Person>();

			var results = from employee in employees
						join person in persons
						on employee.PersonId equals person.PersonId into allEmployees
						from result in allEmployees.DefaultIfEmpty()
						select new PersonEmployeeDto
						{
							BirthDate = result.BirthDate,
							EmployedDate = employee.EmployedDate,
							LastName = result.LastName,
							FirstName = result.FirstName,
							PersonId = result.PersonId,
							EmployeeId = employee.EmployeeId,
							EmployeeNum = employee.EmployeeNum,
							TerminatedDate = employee.TerminatedDate,
						};
			var response = new PersonEmployeeDtos();
			response.Employees = results.ToList();
			return Task.FromResult(response);
		}
	}
}
