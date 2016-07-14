using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestElo.Model
{
    public class Character
    {
        #region properties
        public string CharacterId { get; set; }

        [Key, ForeignKey("Account")]
        public string MembershipId { get; set; }

        public int ReferenceId { get; set; }

        public virtual Account Account { get; set; }
        public DateTime DateLastPlayed { get; set; }
        public decimal TimePlayed { get; set; }
        public DateTime ModifiedOn { get; set; }
        public decimal TrialsElo { get; set; }
        #endregion

        public Character()
        {

        }

    }
}
