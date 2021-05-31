using System;
using CitizenFX.Core.Native;
using CitizenFX.Core;
using Newtonsoft.Json.Linq;
namespace FiveM_Tests.net.Properties
{
    public class ConfigLoader : BaseScript
    {
        private static JObject _config;
        
        public ConfigLoader()
        {
            EventHandlers[$"{API.GetCurrentResourceName()}:Config"] += new Action<string>(ReciveConfig);
            TriggerServerEvent($"{API.GetCurrentResourceName()}:SendConfig");
        }
        private static void ReciveConfig(string config)
        {
            var cfg = JObject.Parse(config);
            _config = cfg;
        }

        public static string GetMensagensConfig(string selectedConfig)
        {
            return _config["Mensagens"][0][selectedConfig].ToString();
        }
    }
}