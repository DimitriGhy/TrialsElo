using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TestElo.Model.Enums.Enums;

namespace TestElo.Model
{
    public class Character
    {

        #region properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CharacterId { get; set; }

        [ForeignKey("Account")]
        public string MembershipId { get; set; }

        public int ReferenceId { get; set; }

        public virtual Account Account { get; set; }
        public DateTime DateLastPlayed { get; set; }
        public decimal TimePlayed { get; set; }
        public DateTime ModifiedOn { get; set; }
        internal Classes classType { get; set; }
        public string ClassName
        {
            get { return this.classType.ToString(); }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    Enum.Parse(typeof(Classes), value);
            }
        }
        #endregion
        public ICollection<Activity> Activities { get; set; }
        public Character()
        {
            Activities = new List<Activity>();
        }

    }
}
