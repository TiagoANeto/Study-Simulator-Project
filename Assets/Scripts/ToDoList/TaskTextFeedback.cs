using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TaskTextFeedback : MonoBehaviour
{
    public TMP_Text taskText;
    public Toggle toggle;

    private void Start()
    {
        toggle.onValueChanged.AddListener(OnToggleChanged);
    }

    void OnToggleChanged(bool isOn)
    {
        if (isOn)
        {
            taskText.fontStyle = FontStyles.Strikethrough;
            taskText.color = new Color(taskText.color.r, taskText.color.g, taskText.color.b, 0.5f); 
        }
        else
        {
            taskText.fontStyle = FontStyles.Normal;
            taskText.color = new Color(taskText.color.r, taskText.color.g, taskText.color.b, 1f);
        }
    }
}
