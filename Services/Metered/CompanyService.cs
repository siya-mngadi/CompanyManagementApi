using CompanyManagement.Dto;
using CompanyManagement.Extensions;
using CompanyManagement.Logger;
using CompanyManagement.Models;
using CompanyManagement.Repositories;
using System.ComponentModel.Design;

namespace CompanyManagement.Services.Metered
{
	internal sealed class CompanyService: ICompanyService
	{
		private readonly IRepositoryManager repository;
		private readonly ILoggerManager logger;

		public CompanyService(IRepositoryManager repository, ILoggerManager logger)
		{
			this.repository = repository;
			this.logger = logger;
		}

		public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
		{
			var companies = repository.company
				.GetAllCompanies(trackChanges)
				.Select(c=> c.MapToCompanyDto())
				.ToList();
			return companies;
		}

		public CompanyDto GetCompany(Guid companyId, bool trackChanges)
		{
			return repository.company
				.GetCompany(companyId, trackChanges)
				?.MapToCompanyDto();
		}

		public CompanyDto CreateCompany(CompanyCreateDto companyDto)
		{
			var company = companyDto.MapToCompany();
			repository.company.CreateCompany(company);
			repository.Save();
			return company?.MapToCompanyDto();
		}
		public void DeleteCompany(Guid companyId, bool trackChanges)
		{
			var company = repository.company.GetCompany(companyId, trackChanges);
			if (company is null) throw new KeyNotFoundException(nameof(Company)); 
			repository.company.DeleteCompany(company); 
			repository.Save();
		}

		public void UpdateCompany(Guid companyId, CompanyCreateDto companyForUpdate, bool trackChanges)
		{
			var companyEntity = repository.company.GetCompany(companyId, trackChanges);
			if (companyEntity is null) throw new KeyNotFoundException(nameof(Company));

			companyEntity.Name = companyForUpdate.Name;
			companyEntity.Address= companyForUpdate.Address;
			companyEntity.Country = companyForUpdate.Country;
			repository.Save();
		}
	}
}
