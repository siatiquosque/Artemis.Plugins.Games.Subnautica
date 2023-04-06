using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Diagnostics;
using System.Reflection;
using System;

namespace Artemis.Plugins.Games.Subnautica.GSI
{
    [BepInPlugin(myGUID, pluginName, versionString)]
    public class Main : BaseUnityPlugin
    {
        private const string myGUID = "Artemis.Plugins.Games.Subnautica.GSI";
        private const string pluginName = "Artemis.Plugins.Games.Subnautica.GSI";
        private const string versionString = "1.0.0";

        public static ArtemisWebClient ArtemisWebClient => _artemisWebClient;
        private static ArtemisWebClient _artemisWebClient;

        private void Awake()
        {
            try
            {
                _artemisWebClient = new ArtemisWebClient(Logger);
            }
            catch (System.Exception e)
            {
                Logger.LogError(e);
                return;
            }
            Harmony harmony = new Harmony(myGUID);
            harmony.PatchAll();

            ArtemisWebClient.StartTimer();
        }

        public void OnApplicationQuit()
        {
            ArtemisWebClient.StopTimer();
        }

    }
}
