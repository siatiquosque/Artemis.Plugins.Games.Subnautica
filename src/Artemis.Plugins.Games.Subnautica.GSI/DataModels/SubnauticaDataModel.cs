using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Artemis.Plugins.Games.Subnautica.GSI.DataModels
{
    internal class SubnauticaDataModel
    {
        public SubnauticaGameState GameState { get; set; }
        public SubnauticaPlayer Player { get; set; }
        public SubnauticaNotification Notification { get; set; }
        public SubnauticaWorld World { get; set; }

        public SubnauticaDataModel()
        {
            GameState = new SubnauticaGameState();

            if (GameState.GameState == GameStateEnum.Playing)
            {
                try
                {
                    Player = new SubnauticaPlayer();
                    Notification = new SubnauticaNotification();
                    World = new SubnauticaWorld();
                } catch {
                    //logger.LogError("Error Playing DataModels");
                }
            }
        }
    }
}
