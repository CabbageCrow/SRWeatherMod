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
            WMShared.SetWeather(__instance);

        }
    }

}