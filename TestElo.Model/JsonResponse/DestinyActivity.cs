using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestElo.Model.JsonResponse.ResponseDestinyActivity
{

    public class ResponseDestinyActivity
    {
        public Response Response { get; set; }
        public int ErrorCode { get; set; }
        public int ThrottleSeconds { get; set; }
        public string ErrorStatus { get; set; }
        public string Message { get; set; }
        public Messagedata MessageData { get; set; }
    }

    public class Response
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public DestinyActivity[] activities { get; set; }
    }

    public class DestinyActivity
    {
        public DateTime period { get; set; }
        public Activitydetails activityDetails { get; set; }
        public Values values { get; set; }
    }

    public class Activitydetails
    {
        public long referenceId { get; set; }
        public string instanceId { get; set; }
        public int mode { get; set; }
        public int activityTypeHashOverride { get; set; }
    }

    public class Values
    {
        public Assists assists { get; set; }
        public Score score { get; set; }
        public Kills kills { get; set; }
        public Averagescoreperkill averageScorePerKill { get; set; }
        public Deaths deaths { get; set; }
        public Averagescoreperlife averageScorePerLife { get; set; }
        public Completed completed { get; set; }
        public Killsdeathsratio killsDeathsRatio { get; set; }
        public Killsdeathsassists killsDeathsAssists { get; set; }
        public Activitydurationseconds activityDurationSeconds { get; set; }
        public Standing standing { get; set; }
        public Team team { get; set; }
        public Completionreason completionReason { get; set; }
        public Fireteamid fireTeamId { get; set; }
        public Playercount playerCount { get; set; }
        public Teamscore teamScore { get; set; }
        public Leaveremainingseconds leaveRemainingSeconds { get; set; }
    }

    public class Assists
    {
        public string statId { get; set; }
        public Basic basic { get; set; }
    }

    public class Basic
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Score
    {
        public string statId { get; set; }
        public Basic1 basic { get; set; }
    }

    public class Basic1
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Kills
    {
        public string statId { get; set; }
        public Basic2 basic { get; set; }
    }

    public class Basic2
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Averagescoreperkill
    {
        public string statId { get; set; }
        public Basic3 basic { get; set; }
    }

    public class Basic3
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Deaths
    {
        public string statId { get; set; }
        public Basic4 basic { get; set; }
    }

    public class Basic4
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Averagescoreperlife
    {
        public string statId { get; set; }
        public Basic5 basic { get; set; }
    }

    public class Basic5
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Completed
    {
        public string statId { get; set; }
        public Basic6 basic { get; set; }
    }

    public class Basic6
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Killsdeathsratio
    {
        public string statId { get; set; }
        public Basic7 basic { get; set; }
    }

    public class Basic7
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Killsdeathsassists
    {
        public string statId { get; set; }
        public Basic8 basic { get; set; }
    }

    public class Basic8
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Activitydurationseconds
    {
        public string statId { get; set; }
        public Basic9 basic { get; set; }
    }

    public class Basic9
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Standing
    {
        public string statId { get; set; }
        public Basic10 basic { get; set; }
    }

    public class Basic10
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Team
    {
        public string statId { get; set; }
        public Basic11 basic { get; set; }
    }

    public class Basic11
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Completionreason
    {
        public string statId { get; set; }
        public Basic12 basic { get; set; }
    }

    public class Basic12
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Fireteamid
    {
        public string statId { get; set; }
        public Basic13 basic { get; set; }
    }

    public class Basic13
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Playercount
    {
        public string statId { get; set; }
        public Basic14 basic { get; set; }
    }

    public class Basic14
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Teamscore
    {
        public string statId { get; set; }
        public Basic15 basic { get; set; }
    }

    public class Basic15
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Leaveremainingseconds
    {
        public string statId { get; set; }
        public Basic16 basic { get; set; }
    }

    public class Basic16
    {
        public decimal value { get; set; }
        public string displayValue { get; set; }
    }

    public class Messagedata
    {
    }
}
