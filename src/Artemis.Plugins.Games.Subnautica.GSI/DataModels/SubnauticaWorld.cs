using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.Subnautica.GSI.DataModels
{
    public class SubnauticaWorld
    {
        public double DayScalar { get; set; }

        public SubnauticaWorld()
        {
            DayScalar = Math.Round(DayNightCycle.main.GetDayScalar(), 2);
        }
    }
}
