using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using AutoMapper;
using PEW.ApplicationServices.Data;
using PEW.Core;
using PEW.Core.Domain;
using PEW.Core.Interfaces.ApplicationServices;
using PEW.Core.Interfaces.Data;

namespace PEW.ApplicationServices
{
	public class EAStatisticsService : AbstractEAStatisticsService, IEAStatisticsService
	{
        private readonly IMailService _mailService;

        public EAStatisticsService(
            IMailService mailService)
        {
            _mailService = mailService;
        }

		#region Implementation of IEAStatisticsService

		/// <summary>
		/// Fetching data for a default user with a default match history post and default game.
		/// </summary>
		/// <returns>A NHLStatistics object</returns>
		public NHLStatistics FetchHockeyStats()
		{
			return FetchHockeyStats(ProjectConstants.DefaultConsoleUser,
			                        ProjectConstants.DefaultGame, 
                                    ProjectConstants.DefaultPlatform);
		}

		/// <summary>
		/// Fetching data for a specified user for a default game.
		/// </summary>
		/// <param name="id">Console nickname</param>
		/// <param name="count">Number of history posts</param>
		/// <returns>A NHLStatistics object</returns>
		public NHLStatistics FetchHockeyStats(string id)
		{
			return FetchHockeyStats(id, ProjectConstants.DefaultGame, ProjectConstants.DefaultPlatform);
		}

		/// <summary>
		/// Fetching data for a specified user, with a specified number of history posts and a specified game.
		/// </summary>
		/// <param name="id">Console nick name</param>
		/// <param name="count">Number of match history posts</param>
		/// <param name="game">A game</param>
		/// <returns>A NHLStatistics object</returns>
		public NHLStatistics FetchHockeyStats(string id, string game)
		{
			return FetchHockeyStats(id, game, ProjectConstants.DefaultPlatform);
		}

        public MatchHistory FetchMatchHistory(string id, string game, int count)
        {
            return FetchMatchHistory(id, game, count, ProjectConstants.DefaultPlatform);
        }

        public LeaderBoard FetchLeaderBoard(string id, int count, string game)
        {
            return FetchLeaderBoard(id, count, game, ProjectConstants.DefaultPlatform);
        }

        public int FetchLevel(string id, string game)
        {
            return FetchLevel(id, game, ProjectConstants.DefaultPlatform);
        }

        public bool HasPlayedNewGame(Core.Domain.Profile profile, bool shouldDeleteMail = true)
        {
            var mails = _mailService.GetInbox(ProjectConstants.SystemEmail, ProjectConstants.SystemEmailPassword);

            foreach (var mail in mails)
            {
                var trimmedSubject = mail.Subject.Replace(" ", "").ToLower();
                if (!trimmedSubject.Contains("easports") || !mail.Message.Contains(profile.GamerTag)) continue;
                if (shouldDeleteMail) _mailService.Delete(ProjectConstants.SystemEmail, ProjectConstants.SystemEmailPassword, mail);
                return true;
            }

            return false;
            
        }

        public IEnumerable<string> AnyPlayedNewGame()
        {
            var list = new List<string>();
            _mailService.ClearInbox(ProjectConstants.SystemEmail, ProjectConstants.SystemEmailPassword);
            return list;
        }


        public int FetchLevel(string id, string game, string platform)
        {
            if (string.IsNullOrEmpty(game)) game = ProjectConstants.DefaultGame;
            if (string.IsNullOrEmpty(platform)) platform = ProjectConstants.DefaultPlatform;

            var item = FetchLeaderBoard(id, 1, game, platform).Mine;
            return item != null ? item.Level : 0;
        }

        public MatchHistory FetchMatchHistory(string id, string game, int count, string platform)
        {
            if (string.IsNullOrEmpty(game)) game = ProjectConstants.DefaultGame;
            if (string.IsNullOrEmpty(platform)) platform = ProjectConstants.DefaultPlatform;

            var history = GetHistory(GetData(string.Format(ProjectConstants.EAHistoryUri, count, id, game, platform.ToUpper())));
            return EAStatisticsAssembler.CreateMatchHistory(history, id);
        }

        public NHLStatistics FetchHockeyStats(string id, string game, string platform)
        {
            var stats = GetStats(GetData(string.Format(ProjectConstants.EAStatisticsUri, id, game, platform.ToUpper())));
            var nhlStats = EAStatisticsAssembler.CreateStats(stats, id);
            nhlStats.Level = nhlStats.GamesPlayed == 0 ? 0 : FetchLevel(id, game, platform);
            nhlStats.Console = platform;
            return nhlStats;
        }
        
        public LeaderBoard FetchLeaderBoard(string id, int count, string game, string platform)
        {
            if (string.IsNullOrEmpty(game)) game = ProjectConstants.DefaultGame;
            if (string.IsNullOrEmpty(platform)) platform = ProjectConstants.DefaultPlatform;

            var json = GetData(string.Format(ProjectConstants.EALeaderBoardUri, id, game, count, platform.ToUpper()));
            var leaderBoard = _jsonSerializer.Deserialize<EALeaderBoardItemContainer>(json);
            return new LeaderBoard { Items = Mapper.Map<IEnumerable<EALeaderBoardItem>, IEnumerable<LeaderBoardItem>>(leaderBoard.data) };
        }

		#endregion
    }

	#region Helper classes

	public abstract class AbstractEAStatisticsService
	{
		protected readonly JavaScriptSerializer _jsonSerializer;

		protected AbstractEAStatisticsService()
		{
			_jsonSerializer = new JavaScriptSerializer();
		}

		protected List<StatisticItem> GetStats(string json)
		{
			var statsList = _jsonSerializer.Deserialize<List<StatisticItem>>(json);
			return statsList;
		}

		protected new List<HistoryItem> GetHistory(string json)
		{
			var historyList = new List<HistoryItem>();
			var jsonList = _jsonSerializer.Deserialize<List<HistoryJsonItem>>(json);

			foreach (var jsonItem in jsonList)
			{
				string handle;

				if (jsonItem.OpponentTeam.Handle.Count == 0) handle = "CPU";
				else handle = jsonItem.OpponentTeam.Handle[0];

				historyList.Add(new HistoryItem(
					 string.Empty,
					 jsonItem.SelfTeam.TeamName,
					 string.Format("{0}-{1}", jsonItem.SelfTeam.Score, jsonItem.OpponentTeam.Score),
					 jsonItem.OpponentTeam.TeamName,
					 handle,
					 false,
                     jsonItem.SelfTeam.TeamId,
                     jsonItem.OpponentTeam.TeamId
				));
			}

			return historyList;
		}

		protected string GetData(string uri)
		{
            //hack for serving nhl-11 stats
            if (uri.Contains("nhl-11")) uri = uri.Replace("versus", "online");

			var webRequest = (HttpWebRequest)WebRequest.Create(uri);
			webRequest.Method = "GET";

            var webResponse = (HttpWebResponse)webRequest.GetResponse();

			Stream responseStream = webResponse.GetResponseStream();
			if (webResponse.ContentEncoding.ToLower().Contains("gzip"))
				responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
			else if (webResponse.ContentEncoding.ToLower().Contains("deflate"))
				responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);

			var sb = new StringBuilder();

			using (var r = new StreamReader(responseStream))
			{
				sb.Append(r.ReadToEnd());
			}

			return sb.ToString();
		}
	}

	public class StatisticItem
	{
		public StatisticItem()
		{ }

		public StatisticItem(string label, string value, string name)
		{
			Label = label;
			Value = value;
            Name = name;
		}

		public string Label { get; set; }
		public string Value { get; set; }
        public string Name { get; set; }
	}

	public class HistoryJsonItem
	{
		public Result Result { get; set; }
		public MatchDetailsSelf SelfTeam { get; set; }
		public MatchDetailsOpponent OpponentTeam { get; set; }
		public string MatchDate { get; set; }
	}

	public class MatchDetailsSelf
	{
		public string TeamName { get; set; }
        public string TeamId { get; set; }
		public string Score { get; set; }
		public string Handle { get; set; }
	}

	public class MatchDetailsOpponent
	{
        public string TeamId { get; set; }
		public string TeamName { get; set; }
		public string Score { get; set; }
		public List<string> Handle { get; set; }
	}

	public class Result
	{
		public string Value { get; set; }
	}

	#endregion
}
