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

        public HeroStatistic(Hero hero, int games, int win)
        {
            Hero = hero;
            Games = games;
            Win = win;
        }
    }
}
