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
                    Console.Write($"{item.LocalizedName}|");
                }

                Console.Write("\n \n \n");
            }

        }
    }
}