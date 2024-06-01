using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Repositories.Metered
{
	public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(RepositoryContext context) : base(context)
		{
		}

		public Company GetCompany(Guid id,bool trackChanges)
		{
			return FindByCondition(x => x.Id.Equals(id), trackChanges)
				.SingleOrDefault();
		}

		public IEnumerable<Company> GetAllCompanies(bool trackChanges)
		{
			return FindAll(trackChanges)
				.OrderBy(c=>c.Name)
				.ToList();
		}

		public void CreateCompany(Company company)
		{
			Create(company);
		}

		public void DeleteCompany(Company company) => Delete(company);
	}
}
