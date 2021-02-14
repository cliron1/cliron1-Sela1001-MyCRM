using Microsoft.EntityFrameworkCore;
using MyCRM.Data.Models;

namespace MyCRM.Data.Contexts {
	public class CustsContext: DbContext {
		public CustsContext() {
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public DbSet<Cust> Custs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer("Server=.; Database=MyCRM; Trusted_Connection=True;");

			//base.OnConfiguring(optionsBuilder);
		}
	}
}
