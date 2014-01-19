using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEW.Core.Domain;

namespace PEW.Web.Controllers.Models
{
	public class BaseViewData
	{
		public enum Tab
		{
			Questions, 
			Exams, 
			Certifications, 
			Home
		}
		public enum Section
		{
			Search, 
			Create, 
			Statistics, 
			Home
		}

		public enum ViewDataMessageType
		{
			Error,
			Information,
		}

		public Tab CurrentTab { get; set; }
		public Section CurrentSection { get; set; }

		/// <summary>
		/// Default model for MasterPage.
		/// </summary>
		public static BaseViewData Default
		{
			get { return new BaseViewData{ CurrentTab = Tab.Home, CurrentSection = Section.Home }; }
		}

		public bool HasMessage()
		{
			return !string.IsNullOrEmpty(MessageText);
		}

		public User LoggedInUser { get; set; }

		public ViewDataMessageType MessageType { get; set; }
		public string MessageText { get; set; }
		public void SetMessage(string message, ViewDataMessageType messageType)
		{
			MessageText = message;
			MessageType = messageType;
		}
	}
}
