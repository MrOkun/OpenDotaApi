using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class Player
    {
        public int Slot { get; private set; }
        public int Id { get; private set; }
        public int Kill { get; private set; }
        public int Death { get; private set; }
        public int Assist { get; private set; }
        public int NetWorth { get; private set; }
        public int CampStacked { get; private set; }
        public int ObserverPlaced { get; private set; }
        public int SentryPlaced { get; private set; }
        public bool Randomed { get; private set; }
        public int RunePickups { get; private set; }
        public int TowerDamage { get; private set; }
        public int TowerKilled { get; private set; }
        public int XpPerMinute { get; private set; }
        public int GoldPerMinute { get; private set; }
        public string Name { get; private set; }
        public string PersonaName { get; private set; }
        public bool IsRadiant { get; private set; }
        public PlayerInventory Inventory { get; private set; }

        public Player(int slot, int id, int kill, int death, int assist, int netWorth, int campStacked, int observerPlaced, int sentryPlaced, bool randomed, int runePickups, int towerDamage, int towerKilled, int xpPerMinute, int goldPerMinute, string name, string personaName, bool isRadiant, PlayerInventory inventory)
        {
            Slot = slot;
            Id = id;
            Kill = kill;
            Death = death;
            Assist = assist;
            NetWorth = netWorth;
            CampStacked = campStacked;
            ObserverPlaced = observerPlaced;
            SentryPlaced = sentryPlaced;
            Randomed = randomed;
            RunePickups = runePickups;
            TowerDamage = towerDamage;
            TowerKilled = towerKilled;
            XpPerMinute = xpPerMinute;
            GoldPerMinute = goldPerMinute;
            Name = name;
            PersonaName = personaName;
            IsRadiant = isRadiant;
            Inventory = inventory;
        }
    }
}
