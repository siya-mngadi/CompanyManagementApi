namespace CompanyManagement.Repositories
{
	public interface IRepositoryManager
	{
		ICompanyRepository company { get; }
		IEmployeeRepository employee { get; }
		void Save();
	}
}
