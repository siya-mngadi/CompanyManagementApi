using CompanyManagement.Dto;
using CompanyManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompanyManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
	private readonly IServiceManager _service;

	public CompanyController(IServiceManager service)
	{
		_service = service;
	}

	[HttpGet]
	public IActionResult GetCompanies()
	{
		var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);
		return Ok(companies);
	}

	[HttpGet("{id:guid}")]
	public IActionResult GetCompany(Guid id)
	{
		var company = _service.CompanyService.GetCompany(id,trackChanges: false);
		if(company == null) throw new KeyNotFoundException($"Company is {id} not found");
		return Ok(company);
	}

	[HttpPost]
	public IActionResult CreateCompany(CompanyCreateDto createDto)
	{
		ArgumentNullException.ThrowIfNull(createDto,nameof(CompanyCreateDto));
		var company = _service.CompanyService.CreateCompany(createDto);
		return Ok(company);
	}

	[HttpDelete("{id:guid}")] 
	public IActionResult DeleteCompany(Guid id) 
	{ 
		_service.CompanyService.DeleteCompany(id, trackChanges: false); 
		return NoContent(); 
	}

	[HttpPut("{id:guid}")]
	public IActionResult UpdateCompany(Guid id, [FromBody] CompanyCreateDto companyCreateDto)
	{
		if (companyCreateDto is null) return BadRequest("companyUpdateDto object is null");
		_service.CompanyService.UpdateCompany(id,companyCreateDto, trackChanges:true);
		return NoContent();
	}
}
