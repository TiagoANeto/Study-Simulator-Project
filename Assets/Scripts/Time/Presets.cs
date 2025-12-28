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
    public GameObject rainBG;
    public Slider sliderRain;

    public GameObject snowWindown;
    public GameObject snowVfx;
    public GameObject snowBG;
    public Slider sliderSnow;


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
        rainBG.SetActive(false);

        snowWindown.SetActive(false);
        snowVfx.SetActive(false);
        snowBG.SetActive(false);

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
        rainBG.SetActive(false);
        
        snowWindown.SetActive(false);
        snowVfx.SetActive(false);
        snowBG.SetActive(false);


        Color backgroundNightColor;
        ColorUtility.TryParseHtmlString("#292965", out backgroundNightColor);
        cam.backgroundColor = backgroundNightColor;
    }

    public void ApplyRainPreset()
    {
        rainWindown.SetActive(true);
        rainVfx.SetActive(true);
        rainBG.SetActive(true);

        ambienceNightLight.SetActive(false);
        ambienceDayLight.SetActive(false);
        sunLight.SetActive(false);
        dayWindown.SetActive(false);
        nightWindown.SetActive(false);
        sunRaysVfx.SetActive(false);

        snowWindown.SetActive(false);
        snowVfx.SetActive(false);
        snowBG.SetActive(false);

        Color rainColor;
        ColorUtility.TryParseHtmlString("#3d5566ff", out rainColor);
        cam.backgroundColor = rainColor;
    }

    public void ApplySnowPreset()
    {
        snowWindown.SetActive(true);
        snowVfx.SetActive(true);
        snowBG.SetActive(true);

        rainWindown.SetActive(false);
        rainVfx.SetActive(false);
        rainBG.SetActive(false);
        ambienceNightLight.SetActive(false);
        ambienceDayLight.SetActive(false);
        sunLight.SetActive(false);
        dayWindown.SetActive(false);
        nightWindown.SetActive(false);
        sunRaysVfx.SetActive(false);

        Color snowColor;
        ColorUtility.TryParseHtmlString("#c0d6e9ff", out snowColor);
        cam.backgroundColor = snowColor;
    }
}
