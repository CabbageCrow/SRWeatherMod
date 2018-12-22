using UModFramework.API;

namespace SRWeatherMod
{
    class SRWeatherMod
    {
        [UMFHarmony(1)]
        public static void Start()
        {
            Log("Slime Rancher Weather Mod v" + UMFMod.GetModVersion().ToString(), true);
        }

        [UMFConfig]
        public static void LoadConfig()
        {
            SRWMConfig.Instance.Load();
        }

        internal static void Log(string text, bool clean = false)
        {
            using (UMFLog log = new UMFLog()) log.Log(text, clean);
        }
    }
}