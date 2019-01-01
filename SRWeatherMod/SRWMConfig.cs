using System;
using UModFramework.API;

namespace SRWeatherMod
{
    internal class SRWMConfig
    {
        private static readonly string configVersion = "1.0";

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
                    cfg.Write("MinVersion", new UMFConfigString("0.50"));
                    //cfg.Write("MaxVersion", new UMFConfigString("0.54.99999.99999")); //Uncomment if a future release is expected to break the mod
                    cfg.Write("UpdateURL", new UMFConfigString(@"https://raw.githubusercontent.com/EmeraldPlay27/SRWeatherMod/master/version.txt"));
                    cfg.Write("ConfigVersion", new UMFConfigString(configVersion));

                    SRWeatherMod.Log("Finished UMF Settings.");



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