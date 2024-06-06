using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoatPlacementSoul : MonoBehaviour, IDropHandler
{
    public GameObject[] SlotPos;
    public GameObject[] OpenSlot;
    public GameObject ParentOf;
    private DragAndDrop IdTransfer;
    private bool FoundPlace = false;
    private IsPosOpen IsOp;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");
        if (eventData.pointerDrag != null)
        {
            IdTransfer = eventData.pointerDrag.GetComponent<DragAndDrop>();
            for (int i = 0; i < OpenSlot.Length; i++)
            {
                if (OpenSlot[i] == null)
                {
                    if (IdTransfer.PreviousSlot != null)
                    {
                        int previousIndex = System.Array.IndexOf(SlotPos, IdTransfer.PreviousSlot);
                        if (previousIndex != -1)
                        {
                            OpenSlot[previousIndex] = null;
                        }
                    }
                    OpenSlot[i] = eventData.pointerDrag;
                    eventData.pointerDrag.transform.position = SlotPos[i].transform.position;
                    eventData.pointerDrag.transform.SetParent(SlotPos[i].transform);
                    IdTransfer.PreviousSlot = SlotPos[i];

                    FoundPlace = true;
                    break;
                }
            }

            eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = true;
            FoundPlace = false;
        }
    }
}