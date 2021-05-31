using System;
using System.IO;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json.Linq;

namespace Fivem_Tests_Server.net
{
    public class ConfigManager : BaseScript
    {
        private static JObject _configFile;

        public ConfigManager()
        {
            EventHandlers[$"{API.GetCurrentResourceName()}:SendConfig"] += new Action<Player>(SendConfigFile);
        }

        public static void Intialize()
        {
            var path = $"{API.GetResourcePath(API.GetCurrentResourceName())}/Config.json";
            if (File.Exists(path))
            {
                var readedFile = File.ReadAllText(path);
                _configFile = JObject.Parse(readedFile);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{API.GetCurrentResourceName()}: Configurações[JSON] carregadas!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{API.GetCurrentResourceName()}: Não é possível carregar o arquivo JSON de configurações do sccript");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void SendConfigFile([FromSource] Player player)
        {
            player.TriggerEvent($"{API.GetCurrentResourceName()}:Config", _configFile.ToString());
        }
    }
}