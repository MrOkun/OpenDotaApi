using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{

    public class Match
    {
        public long MatchId { get; private set; }//
        public int BarracksStatusDire { get; private set; }//
        public int BarracksStatusRadiant { get; private set; }//
        public int DireScore { get; private set; }//
        public int RadiantScore { get; private set; }//
        public int Duration { get; private set; }//
        public int FirstBloodTime { get; private set; }//
        public GameMode GameMode { get; private set; }//
        public bool RadiantWin { get; private set; }//
        public long StartTime { get; private set; }//
        public int TowerStatusDire { get; private set; }//
        public int TowerStatusRadiant { get; private set; }//
        public List<Player> Players { get; private set; }
        public Team Dire { get; private set; }
        public Team Radiant { get; private set; }
        
        /// <summary>
        /// Need to load data. (LoadData)
        /// </summary>
        /// <param name="matchId"></param>
        public Match(long matchId)
        {
            MatchId = matchId;
        }

        public void LoadData()
        {
            Players = new List<Player>();

            var request = new GetRequest($"https://api.opendota.com/api/matches/{MatchId}");

            var json = JObject.Parse("{ \"Data\":" + request.Get() + "}");

            var data = json["Data"];

            BarracksStatusDire = (int)data["barracks_status_dire"];
            BarracksStatusRadiant = (int)data["barracks_status_radiant"];
            DireScore = (int)data["dire_score"];
            RadiantScore = (int)data["radiant_score"];

            var teamJObject = data["radiant_team"];

            if (teamJObject != null)
            {
                int teamId = (int)teamJObject["team_id"];
                string name = (string)teamJObject["name"];
                string tag = (string)teamJObject["tag"];
                string logoUrl = (string)teamJObject["logo_url"];

                Radiant = new Team(teamId, name, tag, logoUrl);
            }
            else
            {
                Radiant = null;
            }

            teamJObject = data["dire_team"];

            if (teamJObject != null)
            {
                int teamId = (int)teamJObject["team_id"];
                string name = (string)teamJObject["name"];
                string tag = (string)teamJObject["tag"];
                string logoUrl = (string)teamJObject["logo_url"];

                Dire = new Team(teamId, name, tag, logoUrl);
            }
            else
            {
                Dire = null;
            }

            Duration = (int)data["duration"];
            FirstBloodTime = (int)data["first_blood_time"];
            GameMode = new GameMode((int)data["game_mode"]);
            RadiantWin = (bool)data["radiant_win"];
            StartTime = (long)data["start_time"];
            TowerStatusDire = (int)data["barracks_status_dire"];
            TowerStatusRadiant = (int)data["barracks_status_radiant"];

            for (int i = 0; i < data["players"].Count(); i++)
            {
                var player = data["players"][i];
                var slot = (int)player["player_slot"];

                int? id = null;

                bool isHidenAccount;

                if ((int?)player["account_id"] != null)
                {
                    isHidenAccount = false;
                    id = (int?)player["account_id"];
                }
                else
                {
                    isHidenAccount = true;
                }

                var kill = (int)player["kills"];
                var assist = (int)player["assists"];
                var death = (int)player["deaths"];
                var netWorth = (int)player["net_worth"];

                int campStacked;

                if ((int?)player["camps_stacked"] == null)
                {
                    campStacked = 0;
                }
                else
                {
                    campStacked = (int)player["camps_stacked"];
                }

                int obs;
                int sentry;

                if ((int?)player["obs_placed"] == null)
                {
                    obs = 0;
                }
                else
                {
                    obs = (int)player["obs_placed"];
                }

                if ((int?)player["sen_placed"] == null)
                {
                    sentry = 0;
                }
                else
                {
                    sentry = (int)player["sen_placed"];
                }

                int runes;

                if ((int?)player["rune_pickups"] == null)
                {
                    runes = 0;
                }
                else
                {
                    runes = (int)player["rune_pickups"];
                }
                
                var towerDamage = (int)player["tower_damage"];

                int towerKilled;

                if ((int?)player["towers_killed"] == null)
                {
                    towerKilled = 0;
                }
                else
                {
                    towerKilled = (int)player["towers_killed"];
                }

                var xpPerMinute = (int)player["xp_per_min"];
                var goldPerMinute = (int)player["gold_per_min"];
                var playerName = (string)player["name"];
                var personaName = (string)player["personaname"];
                var isRadiant = (bool)player["isRadiant"];
                var heroId = (int)player["hero_id"];

                int? item0 = (int?)player["item_0"];
                int? item1 = (int?)player["item_1"];
                int? item2 = (int?)player["item_2"];
                int? item3 = (int?)player["item_3"];
                int? item4 = (int?)player["item_4"];
                int? item5 = (int?)player["item_5"];
                int? itemNeutral = (int?)player["item_neutral"];
                int? backpack0 = (int?)player["backpack_0"];
                int? backpack1 = (int?)player["backpack_1"];
                int? backpack2 = (int?)player["backpack_2"];
                int? backpack3 = (int?)player["backpack_3"];

                var playerInventory = new PlayerInventory(item0, item1, item2, item3, item4, item5, backpack0, backpack1, backpack2, backpack3, itemNeutral);

                playerInventory.FindItems();

                Players.Add(new Player(slot, id, kill, death, assist, netWorth, campStacked, obs, sentry, runes, towerDamage, towerKilled, xpPerMinute, goldPerMinute, playerName, personaName, isRadiant, playerInventory, isHidenAccount, new Hero(heroId)));
            }

        }
    }
}
