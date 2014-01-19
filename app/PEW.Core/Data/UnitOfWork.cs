using PEW.Core.Interfaces.Data;

namespace PEW.Core.Data
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IRavenDbDataContext _dataContext;

        public UnitOfWork(IRavenDbDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		#region Implementation of IUnitOfWork

		public void Commit()
		{
			_dataContext.Save();
		}

		#endregion
	}
}
