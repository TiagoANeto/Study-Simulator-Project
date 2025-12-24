using UnityEngine;

public class BackgroudThemeColors : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        cam = GetComponentInParent<Camera>();
    }

    public void BackgroundColorThemeBlue()
    {
        string hexBlueThemeColorCode = "#5A7D9A";
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
        string hexRedThemeColorCode = "#9C5A2E";
        Color redThemeColorCode;
        ColorUtility.TryParseHtmlString(hexRedThemeColorCode, out redThemeColorCode);
        cam.backgroundColor = redThemeColorCode;
    }

    public void BackgroundColorThemeGreen()
    {
        string hexGreenThemeColorCode = "#4F6B5B";
        Color greenThemeColorCode;
        ColorUtility.TryParseHtmlString(hexGreenThemeColorCode, out greenThemeColorCode);
        cam.backgroundColor = greenThemeColorCode;
    }
}
