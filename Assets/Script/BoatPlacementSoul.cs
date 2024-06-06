using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatPlacementSoul : MonoBehaviour, IDropHandler
{
    public GameObject[] SlotPos;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Droped");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}
