using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMaintenance.Models
{
	public class UpdateEmployeeRequestModel
	{
		[Required]
		public string EmployeeNum { get; set; }
		[Required]
		public DateTime EmployedDate { get; set; }
		public DateTime? TerminatedDate { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public DateTime BirthDate { get; set; }
	}
}
