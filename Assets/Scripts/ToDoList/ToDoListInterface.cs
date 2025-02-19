using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ToDoListInterface : MonoBehaviour
{
   [Header("Panel de grid onde seram instanciadas as tasks")]
   [Space(10)]
   public GameObject grid;

   [Header("Task prefab")]
   [Space(10)]
   public GameObject taskAddPrefab;

   public void AddTask() // metodo para instanciar o prefab que contem as informações de task
   {
        Instantiate(taskAddPrefab, grid.transform);
   }
}
