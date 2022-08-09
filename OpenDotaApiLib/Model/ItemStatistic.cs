using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class ItemStatistic
    {
        public Item Item { get; set; }
        public int Count { get; set; }

        public ItemStatistic(Item item, int count)
        {
            Item = item;
            Count = count;
        }
    }
}
