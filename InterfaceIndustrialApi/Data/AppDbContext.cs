
using Microsoft.EntityFrameworkCore;
using UserCrudApi.Models;

namespace UserCrudApi.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
	}
}
