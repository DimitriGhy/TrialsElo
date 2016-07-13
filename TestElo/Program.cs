using System;
using System.Net.Http;

namespace TestElo
{

    class Program
    {
        const string trialsMode = "14";
        const string rootPath = @"c:\users\public\TrialsElo\";
        static void Main(string[] args)
        {
            //get the leaderboard of PS4
            int page = 0;
            for (int i = 0; i < 5; i++)
            {
                GetLeaderBoardPS4(5);
            }
            
            //push the data in SQL


            string membershipId;
            Console.WriteLine("Enter username...");
            var username = Console.ReadLine();
            if (!string.IsNullOrEmpty(username))
            {
                membershipId = GetMembershipId(username);
                GetElo(membershipId);
                GetEloHistory(membershipId, "2016-06-09", "2016-07-11");
                WeekData(membershipId);
            }
            Console.ReadLine();
            //

        }

        //http://api.guardian.gg/elo/history/4611686018428666800?start=2016-06-09&end=2016-07-09&mode=14 
        static void GetEloHistory(string membershipid, string start, string end, string mode = "14")
        {

            using (var client = new HttpClient())
            {

                var response = client.GetAsync("http://api.guardian.gg/elo/history/" + membershipid + "?start=" + start + "&end=" + end + "&mode=" + mode).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Elo history (" + start + " - " + end + ")");
                Console.WriteLine("---------------------------------------------------");
                foreach (dynamic d in item)
                {
                    var date = d.date;
                    var elo = d.elo;
                    Console.WriteLine(date + ": " + elo);
                }
            }
        }


        //http://api.guardian.gg/leaderboard/2/14/1
        static void GetLeaderBoardPS4(int page, string mode = "14")
        {
            using (var client = new HttpClient())
            {

                var response = client.GetAsync("http://api.guardian.gg/leaderboard/2/" + mode + "/" + page).Result;


                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                dynamic data = item.data;
                foreach (dynamic d in data)
                {
                    var name = d.name;
                    var elo = d.elo;
                    Console.WriteLine(name + ": " + elo);

                }
            }
        }

        static void GetElo(string membershipid)
        {
            // Uses JSON.NET - http://www.nuget.org/packages/Newtonsoft.Json
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://api.guardian.gg/elo/" + membershipid).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                foreach (dynamic d in item)
                {
                    if (d.mode == trialsMode)
                    {
                        var elo = d.elo;
                        var rank = d.rank;
                        Console.WriteLine("---------------------------------------");
                        Console.Write("Current elo: " + elo + "(#" + rank + ")");
                    }
                }

            }
        }

        static string GetMembershipId(string username, string platform = "2") //PS4 = 2, XBONE=1
        {
            // Uses JSON.NET - http://www.nuget.org/packages/Newtonsoft.Json
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://proxy.guardian.gg/Platform/Destiny/SearchDestinyPlayer/" + platform + "/" + username + "/").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                dynamic responseObj = item.Response;
                dynamic data = responseObj[0];
                var membershipId = data.membershipId;
                return membershipId;
            }
        }

        static void WeekData(string mId)
        {
            // Uses JSON.NET - http://www.nuget.org/packages/Newtonsoft.Json
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://api.destinytrialsreport.com/player/" + mId).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
                dynamic thisWeek = item[0].thisWeek;


                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Trials Week data");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Matches played: " + thisWeek[0].matches + "(losses: " + thisWeek[0].losses + ")");
                Console.WriteLine("Kills: " + thisWeek[0].kills);
                Console.WriteLine("Deaths: " + thisWeek[0].deaths);
            }
        }

        static void CharacterData(string mId)
        {
            // Uses JSON.NET - http://www.nuget.org/packages/Newtonsoft.Json
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://trials-api17.herokuapp.com/Platform/Destiny/2/Account/" + mId).Result;
                var content = response.Content.ReadAsStringAsync().Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

            }
        }

        static void TrialsMapData(string week)
        {
            //https://api.destinytrialsreport.com/maps/week/36
        }

        static void getCharacterData(string mId, string cId)
        {
            //GET https://trials-api14.herokuapp.com/Platform/Destiny/Stats/2/4611686018437777945/2305843009263206187/?modes=14&lc=en
        }

        static void getActivities(string mId, string cId, string count = "1") //cid = charachterId, count = number of activities ordered by date (1 = get latest)
        {
            //GET https://trials-api14.herokuapp.com/Platform/Destiny/Stats/ActivityHistory/2/4611686018437777945/2305843009263206187/?mode=14&count=1&lc=en
        }

        #region Retrieve SQL Data
        //Move to different class

        #endregion

        //move to different class
        static void ExportDataToExcel()
        {
            //get all the users and save them to users.csv

            //get the history and save them to history.csv

        }
    }
}
