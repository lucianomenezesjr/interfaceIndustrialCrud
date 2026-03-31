
using Microsoft.EntityFrameworkCore;
using interfaceIndustrialApi.Models;

namespace interfaceIndustrialApi.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Device> Devices { get; set; }
		public DbSet<Sensor> Sensors { get; set; }
		public DbSet<Actuator> Actuators { get; set; }
		public DbSet<SensorData> SensorData { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Device>(entity =>
			{
				entity.HasKey(d => d.Id);
				entity.Property(d => d.Name).IsRequired().HasMaxLength(200);
				entity.Property(d => d.SerialNumber).HasMaxLength(200);
				entity.HasMany(d => d.Sensors).WithOne(s => s.Device!).HasForeignKey(s => s.DeviceId).OnDelete(DeleteBehavior.Cascade);
				entity.HasMany(d => d.Actuators).WithOne(a => a.Device!).HasForeignKey(a => a.DeviceId).OnDelete(DeleteBehavior.Cascade);
			});

			modelBuilder.Entity<Sensor>(entity =>
			{
				entity.HasKey(s => s.Id);
				entity.Property(s => s.Name).IsRequired().HasMaxLength(200);
			});

			modelBuilder.Entity<Actuator>(entity =>
			{
				entity.HasKey(a => a.Id);
				entity.Property(a => a.Name).IsRequired().HasMaxLength(200);
			});

			modelBuilder.Entity<SensorData>(entity =>
			{
				entity.HasKey(sd => sd.Id);
				entity.HasOne<Device>().WithMany().HasForeignKey(sd => sd.DeviceId).OnDelete(DeleteBehavior.Cascade);
				entity.HasOne<Sensor>().WithMany().HasForeignKey(sd => sd.SensorId).OnDelete(DeleteBehavior.Cascade);
			});
		}
	}
}
