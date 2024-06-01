using CompanyManagement.Dto;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
	public interface ICompanyService
	{
		IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
		CompanyDto GetCompany(Guid companyId, bool trackChanges);
		CompanyDto CreateCompany(CompanyCreateDto company);
		void DeleteCompany(Guid companyId, bool trackChanges);
		void UpdateCompany(Guid companyId, CompanyCreateDto companyForUpdate, bool trackChanges);
	}
}
