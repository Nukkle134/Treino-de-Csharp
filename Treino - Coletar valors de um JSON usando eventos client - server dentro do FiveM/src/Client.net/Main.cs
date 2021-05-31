using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using FiveM_Tests.net.Properties;
using Newtonsoft.Json.Linq;

namespace FiveM_Tests.net
{
    public class FiveM : BaseScript
    {
        private const int TimeBetween = 6000;
        private const int WaitToBeAllowing = 4000;
        private static bool _co2;
        private static bool _gasp;
        private static bool _hearthIssues;
        private static bool _chanceToBreath;
        private static bool _hasToBreath;
        private static int _missedBreath;
        
        public FiveM()
        {
            Debug.WriteLine("Breath iniciado!");
            Tick += Check1;
            Tick += ButtomCheck;
        }


        private static void Breath()
        {
            _missedBreath = 0;
            API.Wait(WaitToBeAllowing);
            _co2 = false;
            _gasp = false;
            _hearthIssues = false;
        }

        private static void Prompt()
        {
            
            _hasToBreath = false;
            _chanceToBreath = true;
            switch (_missedBreath)
            {
                case 0:
                    TriggerEvent("Notify", "aviso", ConfigLoader.GetMensagensConfig("Respiração-Aviso0"));
                    break;
                case 1:
                    TriggerEvent("Notify", "aviso", ConfigLoader.GetMensagensConfig("Respiração-Aviso1"));
                    break;
                case 2:
                    TriggerEvent("Notify", "aviso", ConfigLoader.GetMensagensConfig("Respiração-Aviso2"));
                    break;
                case 3:
                    TriggerEvent("Notify", "aviso", ConfigLoader.GetMensagensConfig("Respiração-Aviso3"));
                    break;
            }

            if (!_gasp) _missedBreath++;
            API.Wait(1000);
            _hasToBreath = true;
            _chanceToBreath = true;
        }

  
        private static void Suicide()
        {
            API.Wait(1000);
            _hearthIssues = true;
            _co2 = false;
            var player = new Ped(API.PlayerPedId())
            {
                    
                Health = 0
            };

        }
        
        

        private static async Task Check1()
        {
            await Delay(TimeBetween);
            if (!_co2 && !_hearthIssues || _hasToBreath)
            {
                Prompt();
                switch (_missedBreath)
                {
                    case 1:
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.07f);
                        break;
                    case 2:
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.12f);
                        break;
                    case 3:
                        
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.25f);
                        API.Wait(1000);
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.25f);
                        break;
                    case 4:
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.57f);
                        API.Wait(1000);
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.57f);
                        API.Wait(1000);
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.57f);
                        break;
                    case 5:
                        Suicide();
                        API.ShakeGameplayCam("SMALL_EXPLOSION_SHAKE", 0.00f);
                        break;
                }
            }
            else if (_co2)
            {
                _co2 = false;
                _gasp = false;
                _hearthIssues = false;
            }
            else if (_hasToBreath && _hearthIssues)
            {
                TriggerEvent("Notify", "aviso", "Você morreu");
                _hearthIssues = false;
            }
        }

        private static async Task ButtomCheck()
        {
            await Delay(0);
            if (_chanceToBreath)
                if (API.IsControlPressed(1, 38))
                    Breath();
        }
    }
}