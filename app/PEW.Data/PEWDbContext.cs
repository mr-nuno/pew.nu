using System;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using PEW.Core.Domain;
using PEW.Core.Interfaces.Data;

namespace PEW.Data
{
	public class PewDbContext : DbContext, IDataContext
	{
		public IDbSet<Profile> Profiles { get; set; }
		public new IQueryable<T> Set<T>() where T : class
		{
			return base.Set<T>();
		}

	    public void Save()
		{
			SaveChanges();
		}
	}

	public class PewDbInitializer : DropCreateDatabaseAlways<PewDbContext>
	{
		protected override void Seed(PewDbContext context)
		{

		}
	}
}
