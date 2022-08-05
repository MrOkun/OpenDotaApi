using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class GameMode
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool Balanced { get; private set; }

        public GameMode(int id)
        {
            Id = id;
        }

        public void LoadData()
        {
            var request = new GetRequest($"https://api.opendota.com/api/players/{Id}/wl");

            var json = JObject.Parse("{ \"Data\":" + request.Get() + "}");

            var gamemode = json[Id.ToString()];

            var name = (string)gamemode["name"];

            Name = name;

            try
            {
                var balanced = (bool)gamemode["balanced"];
                Balanced = balanced;
            }
            catch
            {
                Balanced = false;
            }
        }
    }
}
