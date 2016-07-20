using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestElo.Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount
{
    public class RootObject
    {
        public int pageCount { get; set; }
        public int pageSize { get; set; }
        public int totalItems { get; set; }

        public ResponseTrialsReportLeaderBoardAccount[] data { get; set; }
    }

    public class ResponseTrialsReportLeaderBoardAccount
    {

        public string membershipId { get; set; }
        public int membershipType { get; set; }
        public string name { get; set; }
        public string clanName { get; set; }
        public string clanTag { get; set; }
        public decimal elo { get; set; }
        public decimal eloSolo { get; set; }
        public int kills { get; set; }
        public int killsSolo { get; set; }
        public int wins { get; set; }
        public int winsSolo { get; set; }
        public int assists { get; set; }
        public int assistsSolo { get; set; }
        public int deaths { get; set; }
        public int deathsSolo { get; set; }
        public int gamesPlayed { get; set; }
        public int gamesPlayedSolo { get; set; }
        public int timePlayed { get; set; }


    }
}
