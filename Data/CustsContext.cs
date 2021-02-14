using Microsoft.EntityFrameworkCore;
using MyCRM.Entiities;

namespace MyCRM.Data.Contexts {
	public class CustsContext: DbContext {
		public CustsContext(DbContextOptions<CustsContext> options)
			: base(options)
		{
			ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public DbSet<Cust> Custs { get; set; }
		public DbSet<Contact> Contacts { get; set; }
	}
}
