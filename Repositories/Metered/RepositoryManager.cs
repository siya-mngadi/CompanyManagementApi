using CompanyManagement.Data;

namespace CompanyManagement.Repositories.Metered
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext repositoryContext;
		private readonly Lazy<ICompanyRepository> companyRepository;
		private readonly Lazy<IEmployeeRepository> employeeRepository;

		public RepositoryManager(RepositoryContext repositoryContext)
		{
			this.repositoryContext = repositoryContext;
			companyRepository = new Lazy<ICompanyRepository>(()=> new CompanyRepository(repositoryContext));
			employeeRepository = new Lazy<IEmployeeRepository>(()=> new EmployeeRepository(repositoryContext));
		}

		public ICompanyRepository company => companyRepository.Value;

		public IEmployeeRepository employee => employeeRepository.Value;

		public void Save() => repositoryContext.SaveChanges();
	}
}
