using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestElo.Model
{
    public class Account
    {
        #region properties
        [Key]
        public string MembershipId { get; set; }
        public int MembershipType { get; set; }
        public string Region { get; set; }
        public string ClanName { get; set; }
        public string ClanTag { get; set; }
        public int GrimoireScore { get; set; }

        public ICollection<Character> Characters { get; set; }
        public ICollection<Activity> Activities { get; set; }
        #endregion

        public Account()
        {
            Characters = new List<Character>();
            Activities = new List<Activity>();
        }

    }
}
