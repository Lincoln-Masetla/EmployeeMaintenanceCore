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
	public sealed class EditEmployee : DomainCommand<PersonEmployeeDto>
	{
		public string EmployeeNum { get; set; }
		public DateTime EmployedDate { get; set; }
		public DateTime? TerminatedDate { get; set; }
		public int PersonId { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime BirthDate { get; set; }

		public EditEmployee(DomainContext domainContext)
		   : base(domainContext)
		{

		}

		protected override bool VerifyStateInternal()
		{
			var repo = Context.Repository;
			var employee = repo.All<Employee>().First(i => i.EmployeeNum == EmployeeNum);
			var person = repo.All<Person>().First(i => i.PersonId == employee.PersonId);

			if (person == null || employee == null) 
			{
				return false;
			}
			return true;
		}

		protected override Task<PersonEmployeeDto> ExecuteInternal()
		{
			var repo = Context.Repository;

			var employee = repo.All<Employee>().First(i => i.EmployeeNum == EmployeeNum);
			var person = repo.All<Person>().First(i => i.PersonId == employee.PersonId);
			person.LastName = LastName;
			person.FirstName = FirstName;
			person.BirthDate = BirthDate;
			employee.EmployeeNum = EmployeeNum;
			employee.EmployedDate = EmployedDate;
			employee.TerminatedDate = TerminatedDate;

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
