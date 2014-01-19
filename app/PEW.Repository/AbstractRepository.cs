using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEW.Core.Interfaces.Data;

namespace PEW.Repository
{
	public abstract class AbstractRepository
	{
		protected readonly IDataContext _objectContext;

		protected AbstractRepository(IDataContext objectContext)
		{
			_objectContext = objectContext;
		}
	}
}
