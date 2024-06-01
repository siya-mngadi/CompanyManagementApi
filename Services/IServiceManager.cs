﻿namespace CompanyManagement.Services
{
	public interface IServiceManager
	{
		ICompanyService CompanyService { get; }
		IEmployeeService EmployeeService { get; }
	}
}