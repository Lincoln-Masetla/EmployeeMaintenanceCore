using EmployeeMaintenance.Domain.Contexts;
using EmployeeMaintenance.Domain.Entities;
using EmployeeMaintenance.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMaintenance.Domain.Commands.Employees
{
	public sealed class CreateEmployee : DomainCommand<PersonEmployeeDto>
	{

		public string EmployeeNum { get; set; }
		public DateTime EmployedDate { get; set; }
		public DateTime? TerminatedDate { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime BirthDate { get; set; }

		public CreateEmployee(DomainContext domainContext)
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

			var person = new Person
			{
				LastName = LastName,
				FirstName = FirstName,
				BirthDate = BirthDate
			};
			repo.Add(person);
			repo.Commit();
			var employee = new Employee
			{
				PersonId = person.PersonId,
				EmployeeNum = EmployeeNum,
				EmployedDate = EmployedDate,
				TerminatedDate = TerminatedDate
			};
			repo.Add(employee);

			repo.Commit();

			return Task.FromResult(new PersonEmployeeDto
			{
				BirthDate = BirthDate,
				EmployedDate = EmployedDate,
				LastName = LastName,
				FirstName = FirstName,
				PersonId = person.PersonId,
				EmployeeId = employee.EmployeeId,
				EmployeeNum = EmployeeNum,
				TerminatedDate = TerminatedDate,

			});
		}
	}
}
