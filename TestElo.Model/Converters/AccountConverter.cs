using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestElo.Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount;

namespace TestElo.Model.Converters
{
    public class AccountConverter
    {
        public static Account ToAccount(ResponseTrialsReportLeaderBoardAccount trialsAcc)
        {
            Account acc = new Model.Account();

            acc.ClanName = trialsAcc.clanName;
            acc.ClanTag = trialsAcc.clanTag;
            //acc.GrimoireScore = 
            acc.MembershipId = trialsAcc.membershipId;
            acc.MembershipType = trialsAcc.membershipType;
            acc.Kills = trialsAcc.kills;
            acc.Assists = trialsAcc.assists;
            acc.Deaths = trialsAcc.deaths;
            acc.Elo = trialsAcc.elo;
            acc.Name = trialsAcc.name;
            acc.TimePlayed = trialsAcc.timePlayed;
            acc.Wins = trialsAcc.wins;
            acc.GamesPlayed = trialsAcc.gamesPlayed;

            return acc;
        }
    }
}
