using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PEW.Core.Interfaces.Data;

namespace PEW.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
        private readonly IRavenDbDataContext _ravenDbContext;

		public Repository(IRavenDbDataContext ravenDbContext)
		{
		    _ravenDbContext = ravenDbContext;
		}

	    public IQueryable<T> GetAll()
		{
			return _ravenDbContext.Session.Query<T>();
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> where)
		{
            return _ravenDbContext.Session.Query<T>().Where(where);
		}

        public T First(Expression<Func<T, bool>> where)
		{
            return _ravenDbContext.Session.Query<T>().FirstOrDefault(where);
		}

        public T First()
        {
            return _ravenDbContext.Session.Query<T>().FirstOrDefault();
        }

		public void Delete(T entity)
		{
			_ravenDbContext.Session.Delete(entity);
		}

		public void Add(T entity)
		{
            _ravenDbContext.Session.Store(entity);
		}
    }
}
