using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class Hero
    {
        public int Id { get; private set; }
        public string LocalizedName { get; private set; }
        public string Name { get; private set; }
        public string IconURL { get; private set; }
        /// <summary>
        /// Need to load data. (LoadData)
        /// </summary>
        /// <param name="HeroId"></param>
        public Hero(int HeroId)
        {
            Id = HeroId;
        }

        public void LoadData()
        {
            var request = new GetRequest($"https://raw.githubusercontent.com/odota/dotaconstants/master/build/heroes.json");

            var json = JObject.Parse("{ \"Heroes\":" + request.Get() + "}");

            var hero = json["Heroes"][Id.ToString()];

            var localizedName = (string)hero["localized_name"];
            var name = (string)hero["name"];
            var iconUrl = "https://github.com/odota/mobile/tree/master/app/assets/heroes/" + name.Replace("npc_dota_hero_", null) + "_full.png";

            LocalizedName = localizedName;
            Name = name;
            IconURL = iconUrl;
        }
    }
}
