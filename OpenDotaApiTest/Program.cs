using OpenDotaApiLib.Model;

namespace OpenDotaApiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            long matchId = 6696439526;

            var match = new Match(matchId);
            match.LoadData();

            for (int i = 0; i < match.Players.Count; i++)
            {
                Console.WriteLine();

                var players = match.Players;
                var player = players[i];
                var hero = player.Hero;

                if (!player.IsHidenAccount)
                {
                    Console.WriteLine($"{player.PersonaName} with KDA {player.Kill}/{player.Death}/{player.Assist} GpM - {player.GoldPerMinute}, XPpM - {player.XpPerMinute}");
                }
                else
                {
                    Console.WriteLine($"Player {i} with KDA {player.Kill}/{player.Death}/{player.Assist} GpM - {player.GoldPerMinute}, XPpM - {player.XpPerMinute} (Hidden account)");
                }

                Console.Write($"Hero is {hero.LocalizedName} with \n");

                for (int j = 0; j < player.Inventory.Items.Count; j++)
                {
                    var item = player.Inventory.Items[j];
                    item.Load();

                    if (!item.IsNeutral)
                    {
                        Console.Write($"{item.LocalizedName}|");
                    }
                    else
                    {
                        Console.Write($"{item.LocalizedName}(n)|");
                    }
                }

                Console.Write("\n \n \n");

            }

            var heroStat = new HeroStatistic(new Hero(12), 10, 10);

            heroStat.LoadData();
            heroStat.Hero.LoadData();

            Console.WriteLine(heroStat.Hero.LocalizedName);

            for (int i = 0; i < heroStat.Items.Count; i++)
            {
                Console.WriteLine(heroStat.Items[i].Item.Id + "|" + heroStat.Items[i].Item.LocalizedName + "(" + heroStat.Items[i].Count + ")");
            }
        }
    }
}