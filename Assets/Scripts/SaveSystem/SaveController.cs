using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using TMPro;

public class SaveController : MonoBehaviour
{
    public ToDoListInterface toDoListInterface;
    public GameObject taskPrefab;
    public Transform grid;

    private string savePath;

    void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "save.json");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void Save()
    {
        TaskList dataList = new TaskList();

        foreach (Transform child in grid)
        {
            TMP_InputField inputField = child.GetComponentInChildren<TMP_InputField>();
            Toggle toggle = child.GetComponentInChildren<Toggle>();

            TaskData data = new TaskData
            {
                textTask = inputField.text,
                isCompleted = toggle.isOn
            };

            dataList.tasks.Add(data);
        }

        string json = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(savePath, json);
        Debug.Log(json);
    }

    public void Load()
    {
        if (!File.Exists(savePath))
            return;

        string json = File.ReadAllText(savePath);
        TaskList dataList = JsonUtility.FromJson<TaskList>(json);

        // limpar antigas
        foreach (Transform child in grid)
        {
            Destroy(child.gameObject);
        }

        foreach (TaskData data in dataList.tasks)
        {
            GameObject taskGO = Instantiate(taskPrefab, grid);
            taskGO.GetComponentInChildren<TMP_InputField>().text = data.textTask;
            taskGO.GetComponentInChildren<Toggle>().isOn = data.isCompleted;
        }
        Debug.Log(json + "Itens Recarregados com Sucesso");
    }
}
