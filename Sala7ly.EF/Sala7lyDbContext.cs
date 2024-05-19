using Microsoft.EntityFrameworkCore;
using Sala7ly.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sala7ly.EF
{
	public class Sala7lyDbContext : DbContext
	{
		public Sala7lyDbContext(DbContextOptions<Sala7lyDbContext> options) : base(options)
		{
		}

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Merchant> Merchants { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<SpareParts> SpareParts { get; set; }
		public DbSet<Worker> Workers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Admin>().OwnsOne(a => a.HomeAddress);
			modelBuilder.Entity<Client>().OwnsOne(c => c.HomeAddress);
			modelBuilder.Entity<Merchant>().OwnsOne(m => m.ShopAddress);
			modelBuilder.Entity<Worker>().OwnsOne(w => w.HomeAddress);


			modelBuilder.Entity<Payment>()
			.Property(p => p.Price)
			.HasPrecision(18, 2); // Setting precision and scale for Price

			modelBuilder.Entity<SpareParts>()
				.Property(s => s.Price)
				.HasPrecision(18, 2); // Setting precision and scale for Price

			base.OnModelCreating(modelBuilder);
		}
	}
}
