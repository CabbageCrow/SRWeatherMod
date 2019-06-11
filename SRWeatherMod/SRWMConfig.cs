using System;
using UModFramework.API;

namespace SRWeatherMod
{
    internal class SRWMConfig
    {
        private static readonly string configVersion = "1.0";

        public static bool RainEnabled;

        internal void Load()
        {
            SRWeatherMod.Log("Loading settings.");
            try
            {
                using (UMFConfig cfg = new UMFConfig())
                {
                    string cfgVer = cfg.Read("ConfigVersion", new UMFConfigString());
                    if (cfgVer != string.Empty && cfgVer != configVersion)
                    {
                        cfg.DeleteConfig();
                        SRWeatherMod.Log("The config file was outdated and has been deleted. A new config will be generated.");
                    }

                    cfg.Write("SupportsHotLoading", new UMFConfigBool(false));
                    cfg.Read("LoadPriority", new UMFConfigString("Normal"));
                    cfg.Write("MinVersion", new UMFConfigString("0.52"));
                    //cfg.Write("MaxVersion", new UMFConfigString("0.54.99999.99999")); //Uncomment if a future release is expected to break the mod
                    cfg.Write("UpdateURL", new UMFConfigString("https://umodframework.com/updatemod?id=7"));
                    //cfg.Write("UpdateURL", new UMFConfigString(@"https://raw.githubusercontent.com/EmeraldPlay27/SRWeatherMod/master/version.txt"));
                    //cfg.Write("UpdateURL", new UMFConfigString(@"https://umodframework.com/new/updatemod?id="));
                    cfg.Write("ConfigVersion", new UMFConfigString(configVersion));

                    SRWeatherMod.Log("Finished UMF Settings.");

                    RainEnabled = cfg.Read("RainEnabled", new UMFConfigBool(true, false, false), "Should rain be enabled? Changing this setting takes effect immediately, although if raining it won't stop until next weather change.");

                    SRWeatherMod.Log("Finished loading settings.");
                }
            }
            catch (Exception e)
            {
                SRWeatherMod.Log("Error loading mod settings: " + e.Message + " (" + e.InnerException.Message + ")");
            }
        }

        public static SRWMConfig Instance { get; } = new SRWMConfig();
    }
}