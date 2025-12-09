using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public class ToDoListInterface : MonoBehaviour
{
   [Header("Panel de grid onde seram instanciadas as tasks")]
   [Space(10)]
   public GameObject grid;
   private int countInstance = 0;

   [Header("Task prefab")]
   [Space(10)]
   public GameObject taskAddPrefab;

   public void AddTask() 
   {
      if (countInstance < 15)
      {
         Instantiate(taskAddPrefab, grid.transform);
         countInstance++;
      }
      else
      {
         Debug.Log("Limite Max de Tasks");
      }
   }
}
