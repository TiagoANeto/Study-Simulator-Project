// WeatherManager.cs
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor.Presets;

public class WeatherManager : MonoBehaviour
{
    public static WeatherManager Instance;

    [Header("References")]
    public Presets presets;
    

    [Header("Automatic Mode")]
    public bool automaticMode = false; 
    public PresetType automaticPreset = PresetType.SunnyDay; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        ApplyCurrentPreset();
    }

    public void SetPreset(PresetType preset)
    {
        automaticMode = false;
        automaticPreset = preset;
        ApplyCurrentPreset();
    }

    public void SetAutomaticMode(bool enabled)
    {
        automaticMode = enabled;
        if (automaticMode)
        {
            ApplyAutomaticPresetByTime();
        }
        ApplyCurrentPreset();
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

    public void OnRainSliderChanged(float value)
    {
        if (value > 0.01f)
        {
            presets.ApplyRainPreset();
        }
        else
        {
            if (automaticMode)
            {
                ApplyAutomaticPresetByTime(); 
            }
            else
            {
                presets.ApplySunnyDay();
            }
        }
    }
}
