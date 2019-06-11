using UModFramework.API;

namespace SRWeatherMod
{
    class SRWeatherMod
    {
        [UMFHarmony(2)]
        public static void Start()
        {
            Log("Slime Rancher Weather Mod v" + UMFMod.GetModVersion().ToString(), true);
            UMFGUI.RegisterPauseHandler(Pause);
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

        public static void Pause(bool pause)
        {
            TimeDirector timeDirector = null;
            try
            {
                timeDirector = SRSingleton<SceneContext>.Instance.TimeDirector;
            }
            catch { }
            if (!timeDirector) return;
            if (pause)
            {
                if (!timeDirector.HasPauser()) timeDirector.Pause();
            }
            else timeDirector.Unpause();
        }
    }
}