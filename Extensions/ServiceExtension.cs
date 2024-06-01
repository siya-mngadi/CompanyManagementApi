using CompanyManagement.Logger;
using CompanyManagement.Repositories;
using CompanyManagement.Repositories.Metered;
using CompanyManagement.Services;
using CompanyManagement.Services.Metered;

namespace CompanyManagement.Extensions
{
	public static class ServiceExtension
	{
		public static void ConfigureCors(this IServiceCollection services) => 
			services.AddCors(options => 
			{ 
				options.AddPolicy("CorsPolicy", builder => 
				builder.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()); 
			});

		public static void ConfigureRepositoryManager(this IServiceCollection services)=>
			services.AddScoped<IRepositoryManager,RepositoryManager>();

		public static void ConfigureServiceManager(this IServiceCollection services) =>
			services.AddScoped<IServiceManager, ServiceManager>();

		public static void ConfigureLogger(this IServiceCollection services)=> 
			services.AddSingleton<ILoggerManager, LoggerManager>();

	}
}
