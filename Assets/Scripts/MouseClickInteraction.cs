using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickInteraction : MonoBehaviour, IPointerClickHandler
{   
    [Tooltip("Objetos que serão ativados/desativados quando clicar neste objeto")]
    public List<GameObject> toggleObjects = new List<GameObject>();

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleObjects();
    }

    private void ToggleObjects()
    {
        foreach (GameObject obj in toggleObjects)
        {
            if (obj != null)
                obj.SetActive(!obj.activeSelf);
        }
    }
}
