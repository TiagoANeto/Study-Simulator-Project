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
        string hexBlueThemeColorCode = "#92bfe9ff";
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
