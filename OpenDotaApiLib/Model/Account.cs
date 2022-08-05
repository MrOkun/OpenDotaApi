using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class Account
    {
        public int Id { get; private set; }
        public int Games { get; private set; }
        public int Wins { get; private set; }
        public int Loses { get; private set; }
        public string? Name { get; private set; }
        public string PesonaName { get; private set; }
        public long SteamId { get; private set; }
        public string AvatarURL { get; private set; }
        public string ProfileUrl { get; private set; }

        public List<HeroStatistic> Heroes;

        public Account(int playerId)
        {
            Id = playerId;
        }

        public void LoadData()
        {

            Heroes = new List<HeroStatistic>();

            var request = new GetRequest($"https://api.opendota.com/api/players/{Id}/wl");

            var json = JObject.Parse("{ \"PlayerStats\":" + request.Get() + "}");

            var player = json["PlayerStats"];
            var win = player["win"];
            var lose = player["lose"];

            Wins = (int)win;
            Loses = (int)lose;

            var request1 = new GetRequest($"https://api.opendota.com/api/players/{Id}");

            var json1 = JObject.Parse("{ \"Player\":" + request1.Get() + "}");

            var profile = json1["Player"]["profile"];
            var steamid = profile["steamid"];
            var personaName = profile["personaname"];
            var name = profile["name"];
            var avatar = profile["avatar"];
            var profileurl = profile["profileurl"];

            Name = (string?)name;
            PesonaName = (string)personaName;
            AvatarURL = (string)avatar;
            ProfileUrl = (string)profileurl;
            SteamId = (long)steamid;

            var request2 = new GetRequest($"https://api.opendota.com/api/players/{Id}/heroes");

            var json2 = JObject.Parse("{ \"Heroes\":" + request2.Get() + "}");

            for (int i = 0; i < json2["Heroes"].Count(); i++)
            {
                var heroJtoken = json2["Heroes"][i];

                var heroId = (int)heroJtoken["hero_id"];
                var heroGames = (int)heroJtoken["games"];
                var heroWin = (int)heroJtoken["win"];

                var hero = new Hero(heroId);
                hero.LoadData();

                Heroes.Add(new HeroStatistic(hero, heroGames, heroWin));
            }
        }
    }
}
