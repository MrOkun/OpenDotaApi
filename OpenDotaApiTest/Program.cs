using OpenDotaApiLib.Model;

namespace OpenDotaApiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hero = new Hero(12);
            hero.LoadData();

            var match = new Match(6693858360);
            match.LoadData();

            for (int i = 0; i < match.Players.Count; i++)
            {
                var player = match.Players[i];

                if (player.IsHidenAccount)
                {
                    Console.WriteLine($"Player {i} account is hidden!");
                }
                else
                {
                    Console.WriteLine($"Player {match.Players[i].PersonaName}, KDA {match.Players[i].Kill}/{match.Players[i].Death}/{match.Players[i].Assist}");
                }
            }
        }
    }
}