using CompanyManagement.Dto;
using CompanyManagement.Extensions;
using CompanyManagement.Logger;
using CompanyManagement.Repositories;

namespace CompanyManagement.Services.Metered
{
	public class EmployeeService : IEmployeeService
	{ 
		private readonly IRepositoryManager repository;
		private readonly ILoggerManager logger;

		public EmployeeService(IRepositoryManager repository, ILoggerManager logger)
		{
			this.repository = repository;
			this.logger = logger;
		}

		public EmployeeDto GetEmployee(Guid Id, bool trackChanges)
		{
			return repository.employee
				.GetEmployee(Id, trackChanges)?
				.MapToEmployeeDto();
		}

		public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
		{
			var company = repository.company.GetCompany(companyId,trackChanges);
			if(company == null) throw new KeyNotFoundException($"Company id: {companyId} not found");

			return repository.employee.GetEmployees(companyId, trackChanges).Select(e=>e.MapToEmployeeDto());
		}

		public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeCreateUpdateDto employeeForCreation, bool trackChanges)
		{
			var company = repository.company.GetCompany(companyId, trackChanges);
			if (company == null) throw new KeyNotFoundException($"Company id: {companyId} not found");

			var employee = employeeForCreation.MapToEmployee();

			repository.employee.CreateEmployeeForCompany(companyId, employee);
			repository.Save();

			return employee.MapToEmployeeDto();
		}

		public void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges)
		{
			var company = repository.company.GetCompany(companyId, trackChanges);
			if (company is null) throw new KeyNotFoundException(nameof(companyId));

			var employeeForCompany = repository.employee.GetEmployee(id, trackChanges);

			if (employeeForCompany is null) throw new KeyNotFoundException(nameof(companyId));

			repository.employee.DeleteEmployee(employeeForCompany);
			repository.Save();
		}

		public void UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeCreateUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
		{
			var company = repository.company.GetCompany(companyId, compTrackChanges);

			if (company is null) throw new KeyNotFoundException(nameof(companyId));

			var employeeForCompany = repository.employee.GetEmployee(id, empTrackChanges);

			if (employeeForCompany is null) throw new KeyNotFoundException(nameof(companyId));

			var employee = employeeForUpdate.MapToEmployee();
			employeeForCompany.Position = employeeForUpdate.Position;
			employeeForCompany.Name= employeeForUpdate.Name;
			employeeForCompany.Age = employeeForUpdate.Age;
			repository.Save();
		}
	}
}
