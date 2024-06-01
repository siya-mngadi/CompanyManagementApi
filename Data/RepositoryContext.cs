using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Data;

public class RepositoryContext : DbContext
{
	protected readonly IConfiguration _configuration;
	public RepositoryContext(DbContextOptions options, IConfiguration configuration)
		: base(options)
	{
		_configuration = configuration;
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CompanyConfiguration());
		modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		//options;
		base.OnConfiguring(options);
	}

	public DbSet<Company> Companies { get; set; }
	public DbSet<Employee> Employees { get; set; }
}
