using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string LocalizedName { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Need to load data. (Load)
        /// </summary>
        /// <param name="id"></param>
        public Item(int? id)
        {
            if (id != null)
            {
                Id = (int)id;
            }
            else
            {
                Id = 0;
            }
        }

        public void Load()
        {
            if (Id == 0)
            {
                LocalizedName = "Free slot";
                Name = "slot";
            }
            else
            {
                var requestItemId = new GetRequest($"https://raw.githubusercontent.com/odota/dotaconstants/master/build/item_ids.json");

                var json = JObject.Parse("{ \"Data\":" + requestItemId.Get() + "}");

                var itemName = (string)json["Data"][Id.ToString()];

                Name = itemName;

                var requestItemLocalizedName = new GetRequest($"https://raw.githubusercontent.com/odota/dotaconstants/master/build/items.json");

                var jsonLoc = JObject.Parse("{ \"Data\":" + requestItemLocalizedName.Get() + "}");

                string localizedName = "";

                JToken? data = jsonLoc["Data"];

                try
                {
                    if (data[itemName] != null)
                    {
                        var itemDataName = data[itemName];
                        var dname = itemDataName["dname"];

                        localizedName = (string)dname;
                    }
                    else
                    {
                        localizedName = "deleted_item (Error, can't find)";
                    }
                }
                catch
                {
                    localizedName = "deleted_item (Error, can't find)";
                }

                LocalizedName = localizedName;
            }
        }
    }
}
