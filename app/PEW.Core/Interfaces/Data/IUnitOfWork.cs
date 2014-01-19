using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PEW.Core.Interfaces.Data
{
	public interface IUnitOfWork
	{
		void Commit();
	}
}
