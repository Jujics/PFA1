using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatPlacementSoul : MonoBehaviour, IDropHandler
{
    public GameObject[] SlotPos;
    public GameObject ParentOf;
    private DragAndDrop IdTransfer;
    private bool FoundPlace = false;
    private IsPosOpen IsOp;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Droped");
        if (eventData.pointerDrag != null)
        {
            IdTransfer = eventData.pointerDrag.GetComponent<DragAndDrop>();
            int i = 0;
            while (FoundPlace == false || i == SlotPos.Length)
            {

                IsOp = SlotPos[i].GetComponent<IsPosOpen>();
                if (IsOp.isEmpty == false)
                {
                    eventData.pointerDrag.transform.parent = this.gameObject.transform;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                        SlotPos[i].GetComponent<RectTransform>().anchoredPosition;
                    IdTransfer.CurrentBoatPlacementId = IsOp.id;
                    FoundPlace = true;
                    IsOp.isEmpty = true;
                }
                else
                {
                    i += 1;
                }
            }

            eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
            FoundPlace = false;
        }
    }
}