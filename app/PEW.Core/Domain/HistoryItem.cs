using System.Text.RegularExpressions;

namespace PEW.Core.Domain
{
	public class HistoryItem
	{
	    private string _myTeam;
	    private string _opposingTeam;

	    public HistoryItem(string date, string myteam, string finalscore, string opposingteam, string opposingplayer, bool isWon, string myteamid, string opponentteamid)
		{
			Date = date;
			MyTeam = myteam;
			FinalScore = finalscore;
			OpposingTeam = opposingteam;
			OpposingPlayer = opposingplayer;
			IsWon = isWon;
		    MyTeamId = myteamid;
		    OpposingTeamId = opponentteamid;
		}

		public string Date { get; set; }
		public string MyTeam
		{
		    get { return ParseTeamName(_myTeam); }
		    set { _myTeam = value; }
		}

	    public string MyTeamId { get; set; }
		public string FinalScore { get; set; }
		public string OpposingTeam
		{
		    get { return ParseTeamName(_opposingTeam); }
		    set { _opposingTeam = value; }
		}

	    public string OpposingTeamId { get; set; }
		public string OpposingPlayer { get; set; }
		public bool IsWon { get; set; }

	    private string ParseTeamName(string teamName)
	    {
            const string r = @"\[[0-9]\]|\[1[0-9]\]|\[2[0-9]\]";
            if (!Regex.IsMatch(teamName, r, RegexOptions.IgnoreCase)) return teamName;
	        var teamId = 0;
	        var tn = teamName.Trim();
	        var t1 = tn.Remove(0, 1);
	        var t2 = t1.Remove(t1.Length - 1);
	        return int.TryParse(t2, out teamId) 
                ? teamId == 0 ? ProjectConstants.Teams[0] : ProjectConstants.Teams[teamId-1] 
                : teamName;

	    }
	}
}
