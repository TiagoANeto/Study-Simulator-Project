using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SaveController : MonoBehaviour
{
    public static SaveController Instance;

    public Transform grid;
    public GameObject taskPrefab;

    public UserCalendarData calendarData = new UserCalendarData();
    
    string savePath;

    void Awake()
    {
        Instance = this;

        savePath = Path.Combine(Application.persistentDataPath, "save.json");
        Load();
    }

    public void Save()
    {
        SaveData save = new SaveData();

        foreach (Transform child in grid)
        {
            TMP_InputField inputField = child.GetComponentInChildren<TMP_InputField>();
            Toggle toggle = child.GetComponentInChildren<Toggle>();

            TaskData task = new TaskData()
            {
                textTask = inputField.text,
                isCompleted = toggle.isOn
            };

            save.tasks.tasks.Add(task);
        }

        string json = JsonUtility.ToJson(save, true);
        File.WriteAllText(savePath, json);

        Debug.Log("SAVE OK:\n" + json);
    }


    public void Load()
    {
        if (!File.Exists(savePath))
            return;

        string json = File.ReadAllText(savePath);
        SaveData save = JsonUtility.FromJson<SaveData>(json);

        foreach (Transform child in grid)
            Destroy(child.gameObject);

        foreach (TaskData data in save.tasks.tasks)
        {
            GameObject item = Instantiate(taskPrefab, grid);
            item.GetComponentInChildren<TMP_InputField>().text = data.textTask;
            item.GetComponentInChildren<Toggle>().isOn = data.isCompleted;
        }

        Debug.Log("LOAD OK:\n" + json);
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
