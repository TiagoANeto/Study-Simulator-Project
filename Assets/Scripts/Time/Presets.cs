using UnityEngine;
using UnityEngine.UI;

public enum PresetType { SunnyDay, Night, Rain }

public class Presets : MonoBehaviour
{
    public Camera cam;
    public GameObject ambienceNightLight;
    public GameObject ambienceDayLight;
    public GameObject sunLight;
    public GameObject dayWindown;
    public GameObject nightWindown;
    public GameObject sunRaysVfx;

    public GameObject rainWindown;
    public GameObject rainVfx;
    public Slider sliderRain;


    private void Reset()
    {
        if (cam == null) cam = Camera.main;
    }

    public void ApplyPreset(PresetType preset)
    {
        switch (preset)
        {
            case PresetType.SunnyDay: 
                ApplySunnyDay(); 
                break;
            case PresetType.Night: 
                ApplyNight(); 
                break;
            case PresetType.Rain:
                ApplyRainPreset();
                break;
        }
    }

    public void ApplySunnyDay()
    {
        ambienceDayLight.SetActive(true);
        sunLight.SetActive(true);
        dayWindown.SetActive(true);
        sunRaysVfx.SetActive(true);

        ambienceNightLight.SetActive(false);
        nightWindown.SetActive(false);

        Color backgroundDayColor;
        ColorUtility.TryParseHtmlString("#E7A553", out backgroundDayColor);
        cam.backgroundColor = backgroundDayColor;
    }

    public void ApplyNight()
    {
        ambienceNightLight.SetActive(true);
        nightWindown.SetActive(true);

        ambienceDayLight.SetActive(false);
        sunLight.SetActive(false);
        dayWindown.SetActive(false);
        sunRaysVfx.SetActive(false);

        Color backgroundNightColor;
        ColorUtility.TryParseHtmlString("#292965", out backgroundNightColor);
        cam.backgroundColor = backgroundNightColor;
    }

    public void ApplyRainPreset()
    {
        rainWindown.SetActive(true);
        rainVfx.SetActive(true);

        ambienceNightLight.SetActive(false);
        ambienceDayLight.SetActive(false);
        sunLight.SetActive(false);
        dayWindown.SetActive(false);
        nightWindown.SetActive(false);
        sunRaysVfx.SetActive(false);

        Color rainColor;
        ColorUtility.TryParseHtmlString("#3d5566ff", out rainColor);
        cam.backgroundColor = rainColor;
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
