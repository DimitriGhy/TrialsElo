using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestElo.Model.JsonResponse.ResponseDestinyActivity;

namespace TestElo.Model.Converters
{
    public class ActivityConverter
    {
        public static Activity ToActivity(string membershipId, string characterId, DestinyActivity dAct)
        {
            Activity act = new Model.Activity();

            act.MembershipId = membershipId;
            act.CharacterId = characterId;
            act.InstanceId = dAct.activityDetails.instanceId;
            act.ReferenceId = dAct.activityDetails.referenceId;
            act.Mode = dAct.activityDetails.mode;

            act.Period = dAct.period;

            act.ActivityDurationSeconds = dAct.values.activityDurationSeconds.basic.value;
            act.Assists = (int)dAct.values.assists.basic.value;
            act.AverageScorePerKill = dAct.values.averageScorePerKill.basic.value;
            act.AverageScorePerLife = dAct.values.averageScorePerLife.basic.value;
            act.Completed = dAct.values.completed.basic.displayValue;
            act.CompletionReason = dAct.values.completionReason.basic.displayValue;
            act.Deaths = (int)dAct.values.deaths.basic.value;
            act.FireTeamId = dAct.values.fireTeamId.basic.value.ToString();
            act.Kills = (int)dAct.values.kills.basic.value;
            act.KillsDeathsAssists = (int)dAct.values.killsDeathsAssists.basic.value;
            act.KillsDeathsRatio = dAct.values.killsDeathsRatio.basic.value;
            act.LeaveRemainingSeconds = dAct.values.leaveRemainingSeconds.basic.value;
            act.PlayerCount = (int)dAct.values.playerCount.basic.value;
            act.Score = (int)dAct.values.score.basic.value;
            act.Standing = dAct.values.standing.basic.displayValue;
            act.Team = dAct.values.team.basic.displayValue;
            act.TeamScore = dAct.values.teamScore.basic.value;

            return act;
        }
    }
}
