using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestElo.Model
{
    public class Account
    {
        internal int GamesPlayed;
        #region properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MembershipId { get; set; }
        public int MembershipType { get; set; }
        public string Region { get; set; }
        public string ClanName { get; set; }
        public string ClanTag { get; set; }
        public int GrimoireScore { get; set; }
        public decimal Elo { get; set; }
        public string Name { get; set; }
        public int TimePlayed { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public int Assists { get; internal set; }
        public int Kills { get; internal set; }
        public int Deaths { get; internal set; }
        public int Wins { get; internal set; }
        #endregion

        public Account()
        {
            Characters = new List<Character>();
            Activities = new List<Activity>();
        }

    }
}
