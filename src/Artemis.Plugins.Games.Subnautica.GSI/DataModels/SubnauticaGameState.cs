using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Artemis.Plugins.Games.Subnautica.GSI.DataModels
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

        public SubnauticaGameState()
        {
            if (SceneManager.GetActiveScene().name.ToLower().Contains("startscreen"))
                GameState = GameStateEnum.Menu;
            else if (Player.main == null)
                GameState = GameStateEnum.Loading;
            else
                GameState = GameStateEnum.Playing;

        }
    }
}
