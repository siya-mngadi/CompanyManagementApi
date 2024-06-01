using CompanyManagement.Dto;
using CompanyManagement.Models;

namespace CompanyManagement.Repositories
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetEmployees(Guid companyId,bool trackChanges);
		Employee GetEmployee(Guid Id,bool trackChanges);
		void CreateEmployeeForCompany(Guid companyId, Employee employee);
		void DeleteEmployee(Employee employee);
	}
}
