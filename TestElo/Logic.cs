using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestElo.DataLayer;
using TestElo.Model;
using TestElo.Model.Converters;

namespace TestElo
{
    public class Logic
    {
        const string trialsMode = "14";
        const string rootPath = @"c:\users\public\TrialsElo\";
        const string apiKey = "489f18cf6b8c4881bc99c3776950538f";
        static int counter = 0;

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
                Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount.RootObject item = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount.RootObject>(content);
                foreach (var d in item.data)
                {

                    AddAccountToContext(d);
                    //var name = d.name;
                    //var elo = d.elo;
                    //Console.WriteLine(name + ": " + elo);

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
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                var response = client.GetAsync("https://www.bungie.net/platform/Destiny/2/Account/" + mId + "?definitions=false").Result;
                var content = response.Content.ReadAsStringAsync().Result;
                Model.JsonResponse.ResponseDestinyCharacters.ResponseDestinyCharacters item = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.JsonResponse.ResponseDestinyCharacters.ResponseDestinyCharacters>(content);

                AddCharactersToContext(item);




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

        static async Task<string> getBungieActivites(string mId, string cId, string mode = "14", string count = "1", string page = "0")
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                string url = "https://www.bungie.net/Platform/Destiny/Stats/ActivityHistory/2/" + mId + "/" + cId + "/?mode=" + mode + "&page=" + page + "&count=" + count;
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                //dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                return content;
                //Console.WriteLine(item.Response.data.inventoryItem.itemName); //Gjallarhorn
            }
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




        public async Task MainAsync()
        {
            ServicePointManager.DefaultConnectionLimit = 999999;

            List<Task> allPages = new List<Task>();

            for (int i = 0; i <= 50; i++)
            {
                var page = i;
                allPages.Add(processLeaderboard(page));
            }

            await Task.WhenAll(allPages.ToArray());

            Console.WriteLine("Finished Leaderboards");
        }


        public async Task processLeaderboard(Int32 page)
        {
            List<Task> players = new List<Task>();
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                string url = "http://api.guardian.gg/leaderboard/2/" + trialsMode + "/" + page;
                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();
                //var r = content.Result;
                //dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount.ResponseTrialsReportLeaderBoardAccount>(content);
                counter++;
                Console.WriteLine("counter: " + counter);
                var localPage = page;
                Console.WriteLine($"Processing Page: {localPage}");

                Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount.RootObject item = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount.RootObject>(content);
                foreach (var d in item.data)
                {

                    AddAccountToContext(d);
                    //players.Add(Task.Factory.StartNew(() => processGuardian(d, localPage)));
                    players.Add(processGuardian(d));
                }
                await Task.WhenAll(players.ToArray());
            }


            Console.WriteLine($"Finished Page: {page}");
        }


        public async Task processGuardian(dynamic player)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Add("X-API-Key", apiKey);
                string url = "https://api.destinytrialsreport.com/player/" + player.membershipId;
                HttpResponseMessage response = null;
                try
                {
                    response = await client.GetAsync(url);
                }
                catch (Exception ex)
                {
                    var i = 0;
                    while (i <= 5 && response == null)
                    {
                        response = await client.GetAsync(url);
                        i++;
                    }
                }
                var content = await response.Content.ReadAsStringAsync();
                //var r = content.Result;
                dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);

                int totalFlawless = 0;
                int flawlessYear1 = 0;
                int flawlessYear2 = 0;

                dynamic thisWeek = item[0].thisWeek;
                dynamic flawless = item[0].flawless;
                if (flawless.Count == null || flawless.Count > 0)
                {
                    dynamic years = flawless.years;
                    dynamic year1 = years["1"];
                    dynamic year2 = years["2"];
                    if (year1 != null)
                        flawlessYear1 = year1.count;
                    if (year2 != null)
                        flawlessYear2 = year2.count;
                }
                totalFlawless = flawlessYear1 + flawlessYear2;
            }
        }

        #region DB
        static async Task AddActivitiesToContextAsync(string membershipId, string characterId, Model.JsonResponse.ResponseDestinyActivity.ResponseDestinyActivity da)
        {
            using (var context = new EloModelContext())
            {
                foreach (var item in da.Response.data.activities)
                {
                    context.Activities.Add(ActivityConverter.ToActivity(membershipId, characterId, item));
                }
                await context.SaveChangesAsync();
            }
        }

        static void AddActivitiesToContext(string membershipId, string characterId, Model.JsonResponse.ResponseDestinyActivity.ResponseDestinyActivity da)
        {
            using (var context = new EloModelContext())
            {
                context.Database.Connection.Open();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Activities ON");
                context.SaveChanges();
                foreach (var item in da.Response.data.activities)
                {
                    //add filter on date, only insert the new ones instead of looking for upsert
                    Activity entity = ActivityConverter.ToActivity(membershipId, characterId, item);
                    Activity existing = null;
                    if (context.Activities.Count() > 0)
                        existing = context.Activities.FirstOrDefault(o => o.ReferenceId == entity.ReferenceId);

                    if (existing != null)
                        context.Entry(existing).CurrentValues.SetValues(entity);
                    else
                        context.Activities.Add(entity);
                }
                context.SaveChanges();
            }
        }

        static void AddCharactersToContext(Model.JsonResponse.ResponseDestinyCharacters.ResponseDestinyCharacters dc)
        {
            using (var context = new EloModelContext())
            {
                foreach (var jsonC in dc.Response.data.characters)
                {
                    Character c = CharacterConverter.ToCharacter(jsonC);

                    var existing = context.Characters.FirstOrDefault(o => o.CharacterId == c.CharacterId);
                    if (existing != null)
                        context.Entry(existing).CurrentValues.SetValues(c);
                    else
                        context.Characters.Add(c);
                }
                context.SaveChanges();
            }
        }

        static void AddAccountToContext(Model.JsonResponse.ResponseTrialsReportLeaderBoardAccount.ResponseTrialsReportLeaderBoardAccount acc)
        {
            using (var context = new EloModelContext())
            {
                Account newAcc = AccountConverter.ToAccount(acc);
                var existing = context.Accounts.FirstOrDefault(o => o.MembershipId == acc.membershipId);
                if (existing == null)
                    context.Accounts.Add(newAcc);
                else
                {
                    //context
                    context.Entry(existing).CurrentValues.SetValues(newAcc);//.State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }

        }
        #endregion
    }
}
