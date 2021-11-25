using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeMaintenance.Domain.Models
{
	public class PersonEmployeeDto
	{
		public int EmployeeId { get; set; }
		public int PersonId { get; set; }
		public string EmployeeNum { get; set; }
		public DateTime EmployedDate { get; set; }
		public DateTime? TerminatedDate { get; set; }
		public string LastName { get; set; }
		public string FirstName { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
