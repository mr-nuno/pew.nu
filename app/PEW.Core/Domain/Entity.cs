using System;

namespace PEW.Core.Domain
{
	public abstract class IdEntity
	{
		public virtual int Id { get; set; }
	}

	public abstract class Entity : IdEntity
	{
		public virtual DateTime Created { get; set; }
		public virtual string CreatedBy { get; set; }
	}
}