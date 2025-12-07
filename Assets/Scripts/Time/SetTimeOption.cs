using UnityEngine;
using UnityEngine.UI;

public class SetTimeOption : MonoBehaviour
{
    [Header("Referências")]
    public DisplayTime displayTimeScript;  
    public Presets presetsScript;
    public BackgroudThemeColors backgroudColorsScript;          
    public Toggle systemTimeToggle;     

    private void Start()
    {
        systemTimeToggle.onValueChanged.AddListener(OnToggleChanged);
        displayTimeScript.enabled = true;
        presetsScript.enabled = false;
        backgroudColorsScript.enabled = false;
    }

    public void OnToggleChanged(bool useSystemTime)
    {
        displayTimeScript.enabled = useSystemTime;
        presetsScript.enabled = !useSystemTime;
        backgroudColorsScript.enabled = !useSystemTime;
    }
}
