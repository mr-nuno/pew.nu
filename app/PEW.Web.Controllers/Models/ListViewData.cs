using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEW.Core.Domain;

namespace PEW.Web.Controllers.Models
{
	public class ListViewData<T> : BaseViewData where T : Entity
	{
		public List<T> List { get; set; }
	}
}
