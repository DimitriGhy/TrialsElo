using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestElo.Model
{
    public class Activity
    {
        #region properties
        [Key]
        public int ReferenceId { get; set; }
        public virtual Character Character { get; set; }
        [Key, ForeignKey("Account")]
        public string CharacterId { get; set; }

        public DateTime Period { get; set; }

        public string InstanceId { get; set; }
        public int Mode { get; set; }
        public int Assists { get; set; }
        public int Score { get; set; }
        public int Kills { get; set; }
        public decimal AverageScorePerKill { get; set; }
        public int Deaths { get; set; }
        public decimal AverageScorePerLife { get; set; }
        public bool Completed { get; set; }
        public decimal KillsDeathsRatio { get; set; }
        public decimal KillsDeathsAssists { get; set; }
        public decimal ActivityDurationSeconds { get; set; }
        public string Standing { get; set; }
        public string Team { get; set; }
        public string CompletionReason { get; set; }
        public string FireTeamId { get; set; }
        public int PlayerCount { get; set; }
        public decimal TeamScore { get; set; }
        public decimal LeaveRemainingSeconds { get; set; }

        #endregion

        public Activity()
        {

        }
    }
}
