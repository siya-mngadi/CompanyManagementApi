using CompanyManagement.Dto;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly IServiceManager _service;
		
		public EmployeeController(IServiceManager service)
		{
			_service = service;
		}

		[HttpGet]
		public IActionResult GetCompanies(Guid companyId)
		{
			var companies = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);
			return Ok(companies);
		}

		[HttpGet("{id:guid}")]
		public IActionResult GetCompany(Guid id)
		{
			var employee = _service.EmployeeService.GetEmployee(id, trackChanges: false);
			if (employee == null) throw new KeyNotFoundException($"Employee is {id} not found");
			return Ok(employee);
		}

		[HttpPost]
		public IActionResult CreateEmployee(Guid companyId, [FromBody] EmployeeCreateUpdateDto createDto)
		{
			ArgumentNullException.ThrowIfNull(createDto, nameof(EmployeeCreateUpdateDto));
			var employee = _service.EmployeeService.CreateEmployeeForCompany(companyId,createDto, trackChanges: false);
			
			return Ok(employee);
		}

		[HttpDelete("{id:guid}")]
		public IActionResult DeleteEmployee(Guid companyId,Guid id)
		{
			_service.EmployeeService.DeleteEmployeeForCompany(companyId, id, trackChanges: false);
			return NoContent();
		}

		[HttpPut("{id:guid}")] 
		public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeCreateUpdateDto employee) 
		{ 
			if (employee is null) return BadRequest("EmployeeForUpdateDto object is null");
			_service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, compTrackChanges: false, empTrackChanges: true); 
			return NoContent(); 
		}
	}
}
