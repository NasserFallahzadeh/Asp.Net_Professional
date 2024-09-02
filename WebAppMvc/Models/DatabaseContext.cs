using Microsoft.EntityFrameworkCore;
using WebAppMvc.Models.Entities;

namespace WebAppMvc.Models;

public class DatabaseContext:DbContext
{
	public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
	{
		    
	}

	public DbSet<Product> Products { get; set; }
}