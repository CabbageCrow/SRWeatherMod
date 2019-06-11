using UnityEngine;
using HarmonyLib;

namespace SRWeatherMod.Patches
{
    [HarmonyPatch(typeof(AmbianceDirector))]
    [HarmonyPatch("Awake")]
    static class Patch_EnableWeather1
    {
        public static void Postfix(AmbianceDirector __instance)
        {
            __instance.weatherEnabled = SRWMConfig.RainEnabled;
        }
    }

    [HarmonyPatch(typeof(AmbianceDirector))]
    [HarmonyPatch("Update")]
    static class Patch_EnableWeather2
    {
        public static void Prefix(AmbianceDirector __instance)
        {
            __instance.weatherEnabled = SRWMConfig.RainEnabled;
        }
    }
}