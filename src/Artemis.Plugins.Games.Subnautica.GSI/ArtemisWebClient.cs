using Artemis.Plugins.Games.Subnautica.GSI.DataModels;
using BepInEx.Logging;
using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using SystemTimer = System.Timers.Timer;

namespace Artemis.Plugins.Games.Subnautica.GSI
{
    public class ArtemisWebClient
    {
        private const string CONFIG_PATH = @"C:\ProgramData\Artemis\webserver.txt";
        private const string PLUGIN_GUID = "16b8e6cb-722a-426e-b6e1-85412c23c6f1";

        private readonly SystemTimer timer;
        private static string _baseUri;
        private readonly ManualLogSource _logger;

        public ArtemisWebClient(ManualLogSource logger)
        {
            _logger = logger;

            if (!File.Exists(CONFIG_PATH))
                throw new FileNotFoundException("Artemis: Webserver file not found");

            string uri;
            try
            {
                uri = File.ReadAllText(CONFIG_PATH);
            }
            catch (IOException)
            {
                logger.LogError("Artemis: Error reading webserver config file");
                throw;
            }

            logger.LogInfo($"Found artemis web api uri: {uri}");
            _baseUri = $"{uri}plugins/{PLUGIN_GUID}";


            var _client = (HttpWebRequest)WebRequest.Create(_baseUri);

            try
            {
                var stream = _client.GetResponse().GetResponseStream();
                logger.LogInfo(stream.ToString());

            }
            catch (Exception e)
            {
                logger.LogError("Artemis: Failed connecting to webserver");
                logger.LogError(e);

                throw new Exception("Failed to connect to Artemis, exiting...");
            }


            logger.LogInfo("Connected to Artemis, starting timer.");

            timer = new SystemTimer(100);
            timer.Elapsed += OnTimerElapsed;

        }

        public void StartTimer() => timer.Start();
        public void StopTimer() => timer.Stop();

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            //_logger.LogInfo($"#Artemis: SendInfo");
            string json = JsonConvert.SerializeObject(new SubnauticaDataModel());
            SendJson(json);
        }

        public void SendJson(string json)
        {
            try
            {
                //_logger.LogInfo($"{_baseUri}/update");
                //_logger.LogInfo($"{json}");

                //_logger.LogInfo($"ScreenName: {SceneManager.GetActiveScene().name} - Path: {SceneManager.GetActiveScene().path} - isSubScene: {Scree}");

                var request = (HttpWebRequest)WebRequest.Create($"{_baseUri}/update");
                request.ContentType = "application/json";
                request.Method = WebRequestMethods.Http.Post;
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error to Send Json on Update Request");
            }
        }
    }
}
