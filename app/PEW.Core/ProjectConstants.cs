using System.Configuration;

namespace PEW.Core
{
	/// <summary>
	/// A collection of project constants and configuration values.
	/// </summary>
	public class ProjectConstants
	{
        public static string[] Teams = new[] {
                "Anaheim Ducks",
                "Boston Bruins",
                "Buffalo Sabres",
                "Calgary Flames",
                "Carolina Hurricanes",
                "Chicago Blackhawks",
                "Colorado Avalanche",
                "Columbus Blue Jackets",
                "Dallas Stars",
                "Detroit Red Wings",
                "Edmonton OIlers",
                "Florida Panthers",
                "Los Angeles Kings",
                "Minnesota Wild",
                "Montreal Canadiens",
                "Nashville Predators",
                "New Jersey Devils",
                "New Rork Islanders",
                "New York Rangers",
                "Ottawa Senators",
                "Philadelphia Flyers",
                "Phoenix Coyotes",
                "Pittsburgh Penguins",
                "Saint Louis Blues",
                "San Jose Sharks",
                "Tampa Bay Lightning",
                "Toronto Maple Leafs",
                "Vancouver Canucks",
                "Washington Capitals",
                "Winnipeg Jets"
        };

        public const string HtmlTagPattern = "<.*?>";
        public const string EncryptionKey = "Nh75TatZF0rTh3W1n";
        public const string SystemEmail = "pew.stats.nu@gmail.com";
        public const string SystemEmailPassword = "!23456789o";

		/// <summary>
		/// A default nickname
		/// </summary>
		public static string DefaultConsoleUser = ConfigurationManager.AppSettings["DefaultConsoleUser"] ?? "mr_nuno";

		/// <summary>
		/// A default game
		/// </summary>
		public static string DefaultGame = ConfigurationManager.AppSettings["DefaultGame"] ?? "nhl-13";

        /// <summary>
        /// A default game
        /// </summary>
        public static string DefaultPlatform = ConfigurationManager.AppSettings["DefaultPlatform"] ?? "PS3";

		/// <summary>
		/// A default match history count
		/// </summary>
		public static int DefaultHistoryCount = int.Parse(ConfigurationManager.AppSettings["DefaultHistoryCount"]);

		/// <summary>
		/// The service url for the ea service providing data
		/// </summary>
		public static string EAStatisticsUri = ConfigurationManager.AppSettings["StatsServiceUri"];

		/// <summary>
		/// The service url for providing match history
		/// </summary>
		public static string EAHistoryUri = ConfigurationManager.AppSettings["HistoryServiceUri"];

        /// <summary>
        /// The service url for providing match history
        /// </summary>
        public static string EALeaderBoardUri = ConfigurationManager.AppSettings["LeaderBoardServiceUri"];

		/// <summary>
		/// The assembly that hold all resources
		/// </summary>
		public static string ResourceAssembly = "PEW.ApplicationResources";
	}
}
