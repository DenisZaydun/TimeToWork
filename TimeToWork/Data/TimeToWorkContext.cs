using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeToWork.Models;
using ServiceProvider = TimeToWork.Models.ServiceProvider;

namespace TimeToWork.Data
{
    public class TimeToWorkContext : DbContext
    {
        public TimeToWorkContext (DbContextOptions<TimeToWorkContext> options)
            : base(options)
        {
        }

		public DbSet<Service> Services { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<ServiceProvider> ServiceProviders { get; set; }
		public DbSet<ServiceAssignment> ServiceAssignments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Service>().ToTable("Service");
			modelBuilder.Entity<Appointment>().ToTable("Appointment");
			modelBuilder.Entity<Client>().ToTable("Client");
			modelBuilder.Entity<ServiceProvider>().ToTable("ServiceProvider");
			modelBuilder.Entity<ServiceAssignment>().ToTable("ServiceAssignment");

			modelBuilder.Entity<ServiceAssignment>()
				.HasKey(c => new { c.ServiceID, c.ServiceProviderID });
		}
	}
}
