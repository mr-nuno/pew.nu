using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PEW.Core.Interfaces.Data
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> GetAll();
		IEnumerable<T> Find(Expression<Func<T, bool>> where);
        T First(Expression<Func<T, bool>> where);
		T First();

		void Delete(T entity);
		void Add(T entity);
	}
}
