using UnityEngine;
using Harmony;

namespace SRWeatherMod.Patches
{
    [HarmonyPatch(typeof(AmbianceDirector))]
    [HarmonyPatch("Awake")]
    static class Patch_EnableWeather
    {
        public static void Postfix(AmbianceDirector __instance)
        {
            __instance.weatherEnabled = true;
        }
    }
}