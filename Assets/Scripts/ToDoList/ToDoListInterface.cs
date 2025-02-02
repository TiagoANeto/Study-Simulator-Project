using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToDoListInterface : MonoBehaviour
{
   public GameObject grid;
   public GameObject taskAddPrefab;

   public void AddTask()
   {
        Instantiate(taskAddPrefab, grid.transform);
   }
}
