using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Plugins.Games.Subnautica.DataModels
{
    public enum GameStateEnum
    {
        Menu,
        Loading,
        Playing
    }

    public class SubnauticaGameState
    {
        public GameStateEnum GameState { get; set; }

    }
}
