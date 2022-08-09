using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class HeroStatistic
    {
        public Hero Hero { get; private set; }
        public int Games { get; private set; }
        public int Win { get; private set; }
        public List<ItemStatistic> ItemsStart { get; private set; }
        public List<ItemStatistic> ItemsEarly { get; private set; }
        public List<ItemStatistic> ItemsMid { get; private set; }
        public List<ItemStatistic> ItemsLate { get; private set; }
        public List<ItemStatistic> Items { get; private set; }

        public HeroStatistic(Hero hero, int games, int win)
        {
            Hero = hero;
            Games = games;
            Win = win;
        }

        public void LoadData()
        {
            ItemsStart = new List<ItemStatistic>();
            ItemsEarly = new List<ItemStatistic>();
            ItemsMid = new List<ItemStatistic>();
            ItemsLate = new List<ItemStatistic>();

            var requestItemId = new GetRequest($"https://api.opendota.com/api/heroes/{Hero.Id}/itemPopularity");

            var json = JObject.Parse("{ \"Data\":" + requestItemId.Get() + "}");

            var data = json["Data"];

            var itemsStart = data["start_game_items"];
            var itemsEarly = data["early_game_items"];
            var itemsMid = data["mid_game_items"];
            var itemsLate = data["late_game_items"];

            for (int i = 0; i < 1566; i++)
            {
                if (itemsStart[$"{i}"] != null)
                {
                    var count = (int)itemsStart[$"{i}"];

                    var item = new Item(i, false);
                    item.Load();

                    ItemsStart.Add(new ItemStatistic(item, count));
                }

                if (itemsEarly[$"{i}"] != null)
                {
                    var count = (int)itemsEarly[$"{i}"];

                    var item = new Item(i, false);
                    item.Load();

                    ItemsEarly.Add(new ItemStatistic(item, count));
                }

                if (itemsMid[$"{i}"] != null)
                {
                    var count = (int)itemsMid[$"{i}"];

                    var item = new Item(i, false);
                    item.Load();

                    ItemsMid.Add(new ItemStatistic(item, count));
                }

                if (itemsLate[$"{i}"] != null)
                {
                    var count = (int)itemsLate[$"{i}"];

                    var item = new Item(i, false);
                    item.Load();

                    ItemsLate.Add(new ItemStatistic(item, count));
                }

                Items = new List<ItemStatistic>();

                Items.AddRange(ItemsEarly);
                Items.AddRange(ItemsMid);
                Items.AddRange(ItemsLate);
            }
        }
    }
}
