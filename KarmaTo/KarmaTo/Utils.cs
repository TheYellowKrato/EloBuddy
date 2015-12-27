using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;

namespace KarmaTo
{
    class Utils
    {
        public static AIHeroClient getPlayer()
        {
            return ObjectManager.Player;
        }
    }
}
