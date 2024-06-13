using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoGoZone : MonoBehaviour, IDropHandler
{
    public GameObject OnDropTransform;
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
            OnDropTransform.GetComponent<RectTransform>().anchoredPosition;
    }
}
