using CompanyManagement.Dto;
using CompanyManagement.Models;
using System.Runtime.CompilerServices;

namespace CompanyManagement.Extensions
{
	public static class ModelExtension
	{
		public  static Company MapToCompany(this CompanyCreateDto dto)
		{
			return new Company()
			{
				Id = Guid.NewGuid(),
				Address = dto.Address,
				Country = dto.Country,
				Name = dto.Name,
			};
		}

		public static Employee MapToEmployee(this EmployeeCreateUpdateDto dto)
		{
			return new Employee()
			{
				Id = Guid.NewGuid(),
				Age = dto.Age,
				Position = dto.Position,
				Name = dto.Name,
			};
		}
	}
}
