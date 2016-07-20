using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestElo.Model.JsonResponse;

namespace TestElo.Model
{
    public class Activity
    {
        #region properties
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InstanceId { get; set; }

        public long ReferenceId { get; set; }
        public virtual Character Character { get; set; }
        [ForeignKey("Character")]
        public string CharacterId { get; set; }

        [ForeignKey("Account")]
        public string MembershipId { get; set; }
        public virtual Account Account { get; set; }

        public DateTime Period { get; set; }

        public int Mode { get; set; }
        public int Assists { get; set; }
        public int Score { get; set; }
        public int Kills { get; set; }
        public decimal AverageScorePerKill { get; set; }
        public int Deaths { get; set; }
        public decimal AverageScorePerLife { get; set; }
        public string Completed { get; set; }
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
