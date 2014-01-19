using System;
using System.Data.Entity;
using System.Linq;

namespace PEW.Core.Interfaces.Data
{
	public interface IDataContext : IDisposable
	{
		IQueryable<T> Set<T>() where T : class;
		void Save();	
	}
}
