using CompanyManagement.Models;

namespace CompanyManagement.Repositories
{
	public interface ICompanyRepository
	{
		IEnumerable<Company> GetAllCompanies(bool trackChanges);
		Company GetCompany(Guid id, bool trackChanges);
		void CreateCompany(Company company);
		void DeleteCompany(Company company);
	}
}
