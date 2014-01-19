using System.Collections.Generic;
using PEW.Core.Domain;

namespace PEW.Core.Interfaces.ApplicationServices
{
	/// <summary>
	/// Interface for fetching EA statistics from www.ea.com
	/// </summary>
	public interface IEAStatisticsService
	{
        /// <summary>
        /// Check if a any new games has been played.
        /// </summary>
        /// <param name="profile">A profile to check for played games.</param>
        /// <returns>A list of profiles that has played a new game since last check</returns>
        IEnumerable<string> AnyPlayedNewGame();

        /// <summary>
        /// Check if a profile has played a new since last check.
        /// </summary>
        /// <param name="profile">A profile to check for played games.</param>
        /// <returns></returns>
        bool HasPlayedNewGame(Profile profile, bool deleteMail = true);

        /// <summary>
        /// Fetching match history for a specific user and a default console.
        /// </summary>
        /// <returns>A match histiry object</returns>
        MatchHistory FetchMatchHistory(string id, string game, int count);

        /// <summary>
        /// Fetching match history for a specific user and a specified console.
        /// </summary>
        /// <returns>A match histiry object</returns>
        MatchHistory FetchMatchHistory(string id, string game, int count, string platform);

		/// <summary>
		/// Fetching data for a default user with a default match history post and default game.
		/// </summary>
		/// <returns>A NHLStatistics object</returns>
		NHLStatistics FetchHockeyStats();

		/// <summary>
		/// Fetching data for a specified user for a default game.
		/// </summary>
		/// <param name="id">Console nickname</param>
		/// <param name="count">Number of history posts</param>
		/// <returns>A NHLStatistics object</returns>
		NHLStatistics FetchHockeyStats(string id);

		/// <summary>
        /// Fetching data for a specified user, with a specified game and a default console.
		/// </summary>
		/// <param name="id">Console nick name</param>
		/// <param name="count">Number of match history posts</param>
		/// <param name="game">A game</param>
		/// <returns>A NHLStatistics object</returns>
		NHLStatistics FetchHockeyStats(string id, string game);

        /// <summary>
        /// Fetching data for a specified user, with a specified number of history posts and a specified game, and a specified platform.
        /// </summary>
        /// <param name="id">Console nick name</param>
        /// <param name="count">Number of match history posts</param>
        /// <param name="game">A game</param>
        /// <returns>A NHLStatistics object</returns>
        NHLStatistics FetchHockeyStats(string id, string game, string platform);

        /// <summary>
        /// Fetch the current online leaderboard for the default platform
        /// </summary>
        /// <param name="id">The ea id making the request</param>
        /// <param name="count">The count of rows in the result</param>
        /// <param name="game">The game the leaderboard represents</param>
        /// <returns>A leaderboard objeck</returns>
        LeaderBoard FetchLeaderBoard(string id, int count, string game);

        /// <summary>
        /// Fetch the current online leaderboard for a specified platform
        /// </summary>
        /// <param name="id">The ea id making the request</param>
        /// <param name="count">The count of rows in the result</param>
        /// <param name="game">The game the leaderboard represents</param>
        /// <returns>A leaderboard objeck</returns>
        LeaderBoard FetchLeaderBoard(string id, int count, string game, string platform);

        /// <summary>
        /// Fetch my game level 
        /// </summary>
        /// <param name="id">The ea id making the request</param>
        /// <param name="game">The game the leaderboard represents</param>
        /// <returns>An int representing the current level</returns>
        int FetchLevel(string id, string game);

        /// <summary>
        /// Fetch my game level 
        /// </summary>
        /// <param name="id">The ea id making the request</param>
        /// <param name="game">The game the leaderboard represents</param>
        /// <returns>An int representing the current level</returns>
        int FetchLevel(string id, string game, string platform);
	}
}
