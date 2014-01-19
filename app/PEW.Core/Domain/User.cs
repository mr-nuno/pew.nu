using System;

namespace PEW.Core.Domain
{
	/// <summary>
	/// Represents a user in the system
	/// </summary>
	public class User : Entity
	{
		public virtual string FirstName { get; set; }
		public virtual string LastName { get; set; }
		public virtual string Email { get; set; }
		public virtual string EAId { get; set; }
	}
}
