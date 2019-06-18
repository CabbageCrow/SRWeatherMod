using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SRWeatherMod
{
    internal static class WMShared
    {
        internal static void SetWeather(AmbianceDirector ambianceDirector)
        {
            switch (SRWMConfig.WeatherOption)
            {
                case WeatherOptions.No_Weather:
                    ambianceDirector.weatherEnabled = false;
                    ambianceDirector.worldModel.currWeather = AmbianceDirector.Weather.NONE;
                    ambianceDirector.weatherAttach.SetWeather(ambianceDirector.weatherPrefabs[ambianceDirector.worldModel.currWeather]);
                    break;
                case WeatherOptions.Always_Raining:
                    ambianceDirector.weatherEnabled = false;
                    ambianceDirector.worldModel.currWeather = AmbianceDirector.Weather.RAIN;
                    ambianceDirector.weatherAttach.SetWeather(ambianceDirector.weatherPrefabs[ambianceDirector.worldModel.currWeather]);
                    break;
                case WeatherOptions.Changing_Weather:
                    ambianceDirector.weatherEnabled = true;
                    break;

            }
        }
    }
}
