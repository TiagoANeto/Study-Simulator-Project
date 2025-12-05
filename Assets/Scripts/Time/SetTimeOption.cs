using UnityEngine;

public class SetTimeOption : MonoBehaviour
{
    DisplayTime timeOfDay;
    Presets presets;

    private void Awake()
    {
        timeOfDay = GetComponentInChildren<DisplayTime>();
        presets = GetComponentInChildren<Presets>();
    }

    public void SetTypeOfDayTime()
    {
        timeOfDay.enabled = true;
        presets.enabled = false;
    }
}
