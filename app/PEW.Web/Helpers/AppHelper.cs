using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PEW.Web.Controllers.Models;

namespace PEW.UI.Web.Helpers
{
	public class AppHelper
	{
		/// <summary>
		/// Returns the path to the content folder.
		/// </summary>
		/// <returns></returns>
		public static string GetContentRoot()
		{
			return VirtualPathUtility.ToAbsolute("~/Content");
		}

		/// <summary>
		/// Returns the path of a specific image.
		/// </summary>
		/// <param name="file">The filename of the image.</param>
		/// <returns></returns>
		public static string GetImage(String file)
		{
			return string.Format("{0}/{1}/{2}", GetContentRoot(), "Images", file);
		}

		/// <summary>
		/// Returns the path a specific css file.
		/// </summary>
		/// <param name="file">The filename of the stylesheet.</param>
		/// <returns></returns>
		public static string GetCss(String file)
		{
			/*var fileNameWithoutExtension = file.Substring(0, file.LastIndexOf("."));
			var fileName = file;
			if (HttpContext.Current.IsDebuggingEnabled) fileName = fileNameWithoutExtension + ".debug.css";*/
			return string.Format("{0}/{1}/{2}", GetContentRoot(), "Styles", file);
		}

		/// <summary>
		/// Returns the path a specific js file.
		/// </summary>
		/// <param name="file">The filename of the script.</param>
		/// <returns></returns>
		public static string GetJavaScript(String file)
		{
			return string.Format("{0}/{1}/{2}", GetContentRoot(), "Scripts", file);
		}

		public static object IsCurrentTab(BaseViewData.Tab currentTab, BaseViewData.Tab masterTab)
		{
			return currentTab == masterTab ? new { @class = "current" } : new { @class = "" };
		}

		public static string IsCurrentSection(BaseViewData.Section currentSection, BaseViewData.Section masterSection)
		{
			return currentSection == masterSection ? "class=\"current\"" : string.Empty;
		}

		public static string CreateSectionLinkFor(BaseViewData.Section section, BaseViewData.Tab currentTab, BaseViewData.Section currentSection)
		{
			switch(currentTab)
			{
				case BaseViewData.Tab.Questions:
					return string.Format("<a href=\"{0}\">{1}</a>", currentTab, currentTab);
				case BaseViewData.Tab.Exams:
					return string.Format("<a href=\"{0}\">{1}</a>", currentTab, currentTab);
				case BaseViewData.Tab.Certifications:
					return string.Format("<a href=\"{0}\">{1}</a>", currentTab, currentTab);
				case BaseViewData.Tab.Home:
					return string.Format("<a href=\"{0}\">{1}</a>", currentTab, currentTab);
				default:
					throw new ArgumentOutOfRangeException("currentTab");
			}
		}
	}
}