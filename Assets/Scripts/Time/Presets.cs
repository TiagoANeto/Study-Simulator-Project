using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Presets : MonoBehaviour
{
    public Camera cam;
    public GameObject ambienceNightLight;
    public GameObject ambienceDayLight;
    public GameObject sunLight;
    public GameObject dayWindown;
    public GameObject nightWindown;
    public GameObject rainWindown;
    public GameObject rainVfx;
    public GameObject sunRaysVfx;

    public Slider sliderRain;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void PresetSunnyDay()
    {
        ambienceDayLight.SetActive(true);
        sunLight.SetActive(true);
        dayWindown.SetActive(true);
        sunRaysVfx.SetActive(true);

        ambienceNightLight.SetActive(false);
        nightWindown.SetActive(false);

        string hexDayColorCode = "#E7A553";
        Color backgroundDayColor;
        ColorUtility.TryParseHtmlString(hexDayColorCode, out backgroundDayColor);
        cam.backgroundColor = backgroundDayColor;
    }
    
    public void PresetNight()
    {
        ambienceNightLight.SetActive(true);
        nightWindown.SetActive(true);

        ambienceDayLight.SetActive(false);
        sunLight.SetActive(false);
        dayWindown.SetActive(false);
        sunRaysVfx.SetActive(false);

        string hexNightColorCode = "#292965";
        Color backgroundNightColor;
        ColorUtility.TryParseHtmlString(hexNightColorCode, out backgroundNightColor);
        cam.backgroundColor = backgroundNightColor;
    }

    private void PresetRain()
    {
        if (sliderRain.value >= 0.01)
        {
            rainWindown.SetActive(true);
            rainVfx.SetActive(true);

            nightWindown.SetActive(false);
            ambienceNightLight.SetActive(false);
            ambienceDayLight.SetActive(false);
            sunLight.SetActive(false);
            dayWindown.SetActive(false);
            sunRaysVfx.SetActive(false);

            string hexRainColorCode = "#3d5566ff";
            Color backgroundRainColor;
            ColorUtility.TryParseHtmlString(hexRainColorCode, out backgroundRainColor);
            cam.backgroundColor = backgroundRainColor;
        }
        else
        {
            rainWindown.SetActive(false);
            rainVfx.SetActive(false);
        }

    }

    public void BackgroundColorThemeBlue()
    {
        string hexBlueThemeColorCode = "#60a6e7ff";
        Color blueThemeColorCode;
        ColorUtility.TryParseHtmlString(hexBlueThemeColorCode, out blueThemeColorCode);
        cam.backgroundColor = blueThemeColorCode;
    }

    public void BackgroundColorThemePurple()
    {
        string hexPurpleThemeColorCode = "#251E35";
        Color purpleThemeColorCode;
        ColorUtility.TryParseHtmlString(hexPurpleThemeColorCode, out purpleThemeColorCode);
        cam.backgroundColor = purpleThemeColorCode;
    }

    public void BackgroundColorThemeRed()
    {
        string hexRedThemeColorCode = "#ca6969ff";
        Color redThemeColorCode;
        ColorUtility.TryParseHtmlString(hexRedThemeColorCode, out redThemeColorCode);
        cam.backgroundColor = redThemeColorCode;
    }

    public void BackgroundColorThemeGreen()
    {
        string hexGreenThemeColorCode = "#203d0dff";
        Color greenThemeColorCode;
        ColorUtility.TryParseHtmlString(hexGreenThemeColorCode, out greenThemeColorCode);
        cam.backgroundColor = greenThemeColorCode;
    }
}
