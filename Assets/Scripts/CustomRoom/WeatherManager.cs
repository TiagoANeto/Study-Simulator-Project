// WeatherManager.cs
using UnityEngine;
using UnityEngine.UI;
using System;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager Instance;

    [Header("References")]
    public Presets presets;
    public GameObject rainWindown;
    public GameObject rainVfx;
    public Slider sliderRain;

    [Header("Automatic Mode")]
    public bool automaticMode = false; 
    public PresetType automaticPreset = PresetType.SunnyDay; 

    //estado atual
    private float rainAmount = 0f; 
    private bool rainEnabled => rainAmount > 0.01f;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ApplyCurrentPreset();
        ApplyRainState();
    }

    public void SetRainAmount(float value)
    {
        rainAmount = Mathf.Clamp01(value);
        ApplyRainState();
    }

    public void SetPreset(PresetType preset)
    {
        automaticMode = false;
        automaticPreset = preset;
        ApplyCurrentPreset();
        ApplyRainState();
    }

    public void SetAutomaticMode(bool enabled)
    {
        automaticMode = enabled;
        if (automaticMode)
        {
            ApplyAutomaticPresetByTime();
        }
        ApplyCurrentPreset();
        ApplyRainState();
    }

    private void ApplyCurrentPreset()
    {
        if (presets == null) return;

        PresetType toApply = automaticMode ? automaticPreset : automaticPreset;
        presets.ApplyPreset(toApply);
    }

    private void ApplyAutomaticPresetByTime()
    {
        int hour = DateTime.Now.Hour;
        if (hour >= 6 && hour < 18)
            automaticPreset = PresetType.SunnyDay;
        else
            automaticPreset = PresetType.Night;
    }

    private void ApplyRainState()
    {
        bool shouldRain = rainEnabled;
        if(sliderRain.value >= 0.01f)
        {
            if (rainWindown != null) rainWindown.SetActive(shouldRain);
            if (rainVfx != null) rainVfx.SetActive(shouldRain);
        }

    }

    public void ToggleRain()
    {
        float newVal = rainEnabled ? 0f : 1f;
        if (sliderRain != null) sliderRain.value = newVal;
        SetRainAmount(newVal);
    }
}
