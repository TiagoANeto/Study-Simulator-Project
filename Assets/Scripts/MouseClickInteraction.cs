using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClickInteraction : MonoBehaviour, IPointerClickHandler
{
    public GameObject abajurLight;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        abajurLight.SetActive(!abajurLight.activeInHierarchy);
    }

}
