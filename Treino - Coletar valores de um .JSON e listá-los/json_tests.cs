using System;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;

namespace testes_json
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var getConfig = new JObject();
            var config = new JObject();
            var configPath = @"C:\Users\nukkle\RiderProjects\testes_json\testes_json\Config.json";
            if (File.Exists(configPath))
            {
                var readFile = File.ReadAllText(configPath, Encoding.UTF8);
                var reader = JObject.Parse(readFile);
                foreach (var users in reader["Blips"].Children<JObject>())
                foreach (var cat in users.Properties())
                {
                    var x = cat.Value[0]["Coords"][0];
                    var y = cat.Value[0]["Coords"][1];
                    var z = cat.Value[0]["Coords"][2];
                    var cor = cat.Value[0]["Cor"];
                    var type = cat.Value[0]["Type"];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"Usuario:{cat.Name} || Cor: {cor} || Coords: x:{x}, y:{y}, z: {z}, || Tipo:{type}");
                }
            }
        }
    }
}