using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeMaintenance.Domain.Commands.Employees;
using EmployeeMaintenance.Domain.Contexts;
using EmployeeMaintenance.Domain.Models;
using EmployeeMaintenance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeMaintenance.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly DomainContext domainContext;
		private readonly ILogger<EmployeeController> _logger;

		public EmployeeController(ILogger<EmployeeController> logger, DomainContext domainContext)
		{
			_logger = logger;
			this.domainContext = domainContext;
		}

		[HttpPost(nameof(Create))]
		public async Task<IActionResult> Create([FromBody] CreateEmployeeRequestModel request)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest("Request state is invalid");
			}

			try
			{
				var createEmployee = new CreateEmployee(domainContext)
				{
					BirthDate = request.BirthDate,
					EmployedDate = request.EmployedDate,
					EmployeeNum = request.EmployeeNum,
					FirstName = request.FirstName,
					LastName = request.LastName,
					TerminatedDate = request.TerminatedDate
				};

				var employee = await createEmployee.ExecuteAsync();


				return Ok(employee);
			}
			catch (Exception e)
			{
				return BadRequest();
			}

		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			try
			{
				var employees = new GetManyEmployees(domainContext)
				{
					Employees = true
				};
				var results = await employees.ExecuteAsync();

				return Ok(results);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpPost(nameof(Update))]
		public async Task<IActionResult> Update([FromBody] UpdateEmployeeRequestModel request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("Request state is invalid");
			}

			try
			{
				var editEmployee = new EditEmployee(domainContext)
				{
					BirthDate = request.BirthDate,
					EmployedDate = request.EmployedDate,
					EmployeeNum = request.EmployeeNum,
					FirstName = request.FirstName,
					LastName = request.LastName,
					TerminatedDate = request.TerminatedDate
				};

				var employee = await editEmployee.ExecuteAsync();


				return Ok(employee);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}

		[HttpPost(nameof(Delete))]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			try
			{
				await new DeleteEmployee(domainContext)
				{
					PersonId = id

				}.ExecuteAsync();

				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync([FromRoute] int id)
		{
			try
			{
				var employee = new GetOneEmployee(domainContext)
				{
					EmployeeId = id
				};

				var results = await employee.ExecuteAsync();

				return Ok(results);
			}
			catch (Exception e)
			{
				return BadRequest();
			}
		}
	}
}
	