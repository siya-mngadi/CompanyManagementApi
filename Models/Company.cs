using CompanyManagement.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models;

public class Company
{
	[Column("CompanyId")]
	public Guid Id { get; set; }

	[Required(ErrorMessage = "Company name is a required field.")]
	[MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
	public string Name { get; set; }

	public string Country { get; set; }

	[Required(ErrorMessage = "Company address is a required field.")]
	[MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
	public string Address { get; set; }

	public ICollection<Employee> Employees { get; set; }

	public CompanyDto MapToCompanyDto () =>
		new CompanyDto(Id, Name ?? "", string.Join(' ', Address, Country));
}
