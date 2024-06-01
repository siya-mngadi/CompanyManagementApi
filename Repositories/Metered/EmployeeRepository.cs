using CompanyManagement.Data;
using CompanyManagement.Dto;
using CompanyManagement.Models;

namespace CompanyManagement.Repositories.Metered
{
	public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
	{
		public EmployeeRepository(RepositoryContext context) 
			: base(context)
		{
		}

		public Employee GetEmployee(Guid Id, bool trackChanges)
		{
			return FindByCondition(x => x.Id.Equals(Id), trackChanges)
				.SingleOrDefault();
		}

		public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
		{
			return FindByCondition(e=>e.CompanyId.Equals(companyId), trackChanges)
				.OrderBy(x => x.Name)
				.ToList();
		}

		public void CreateEmployeeForCompany(Guid companyId, Employee employee)
		{
			employee.CompanyId = companyId;
			Create(employee);
		}

		public void DeleteEmployee(Employee employee) => Delete(employee);
	}
}
