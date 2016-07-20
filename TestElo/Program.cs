using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestElo.DataLayer;
using TestElo.Model;
using TestElo.Model.Converters;

namespace TestElo
{

    class Program
    {
        const string trialsMode = "14";
        const string rootPath = @"c:\users\public\TrialsElo\";
        const string apiKey = "489f18cf6b8c4881bc99c3776950538f";
        static int counter = 0;

        static void Main(string[] args)
        {
            string membershipId = "4611686018439432963";
            string characterId = "2305843009290018353";

            //GetLeaderBoardPS4(2000);
            RunAsync();
            //Console.ReadLine();



            //insert/update all the players

            //insert update all the characters
            //CharacterData(membershipId);
            //insert only the new activities

            //CharacterData(membershipId);

            //testContext();


            //var x = getBungieActivites(membershipId, characterId, trialsMode, "30", "0");
            //var acc = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.JsonResponse.ResponseDestinyActivity.ResponseDestinyActivity>(x.Result);

            //AddActivitiesToContext(membershipId, characterId, acc);




            //CharacterData(membershipId);

            //get the leaderboard of PS4
            //int page = 0;
            //for (int i = 0; i < 5; i++)
            //{
            //    GetLeaderBoardPS4(5);
            //}

            //push the data in SQL


            //Console.WriteLine("Enter username...");
            //var username = Console.ReadLine();
            //if (!string.IsNullOrEmpty(username))
            //{
            //    membershipId = GetMembershipId(username);
            //    GetElo(membershipId);
            //    GetEloHistory(membershipId, "2016-06-09", "2016-07-11");
            //    WeekData(membershipId);
            //    CharacterData(membershipId);
            //}
            //Console.ReadLine();
            //

        }
        static void RunAsync()
        {
            Stopwatch timePerParse;
            double ticksAsync = 0, ticksNormal = 0;

            //Async call
            timePerParse = Stopwatch.StartNew();

            //AsyncWorker worker = new AsyncWorker();
            //worker.ProcessAsync().Wait();
            Task.Run(() => new Logic().MainAsync()).Wait();
            
            timePerParse.Stop();
            ticksAsync = timePerParse.Elapsed.TotalSeconds;
            Console.WriteLine($"Async run: {ticksAsync}");
        }



    }



}
