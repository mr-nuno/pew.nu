using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PEW.Core.Domain
{
    public class Profile
    {
        [Key, Column("Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LastVisit { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gravatar { get; set; }
        
        public int HistoryCount { get; set; }
        public string Theme { get; set; }

        [Required]
        public string GamerTag { get; set; }

        [Required]
        public string Game { get; set; }

        [Required]
        public string Console { get; set; }
        public IEnumerable<Friend> Friends { get; set; }

        public int LatestPoints { get; set; }
        public string LatestGameCheck { get; set; }

        public bool Web { get; set; }
        public bool App { get; set; }

        public IEnumerable<Friend> AllFriendsAndMe()
        {
            return new List<Friend>(Friends) { new Friend {GamerTag = GamerTag, Console = Console }};
        }

        public static Profile Create(string gamerTag, string game, string console, IEnumerable<Friend> friends)
        {
            return new Profile { GamerTag = gamerTag, Game = game, Console = console, Friends = friends };
        }

        public static Profile Create(string gamerTag, string game, string console)
        {
            return Create(gamerTag, game, console, new List<Friend>());
        }
    }
}
