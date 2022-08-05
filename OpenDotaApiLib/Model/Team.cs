using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDotaApiLib.Model
{
    public class Team
    {
        public int TeamId { get; private set; }
        public string Name { get; private set; }
        public string Tag { get; private set; }
        public string LogoUrl { get; private set; }

        public Team(int teamId, string name, string tag, string logoUrl)
        {
            TeamId = teamId;
            Name = name;
            Tag = tag;
            LogoUrl = logoUrl;
        }
    }
}
