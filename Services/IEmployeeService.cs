using CompanyManagement.Dto;

namespace CompanyManagement.Services
{
	public interface IEmployeeService
	{
		IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
		EmployeeDto GetEmployee(Guid Id, bool trackChanges);
		EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeCreateUpdateDto employeeForCreation, bool trackChanges);
		void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);
		void UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeCreateUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);
	}
}
