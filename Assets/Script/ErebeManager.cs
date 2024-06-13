using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class ErebeManager : MonoBehaviour, IDropHandler
{
    List<GameObject> ErebeList = new List<GameObject>();
    public RectTransform ErebePlace;
    public int i;
    private bool doorOpen = true;
    

    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<CanvasGroup>().blocksRaycasts = false;
        GameObject Dropped = eventData.pointerDrag;
        Dropped.GetComponent<SoulDataGrab>().InErebe = true;
        ErebeList.Add(Dropped);
        Dropped.GetComponent<RectTransform>().anchoredPosition = ErebePlace.anchoredPosition;
        i++;
    }

    public void Remove()
    {
        int x = -900;
        int y = 59;
        foreach (GameObject Obj in ErebeList)
        {
            Obj.GetComponent<SoulDataGrab>().InErebe = false;
            Obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            if(x > 450)
            {
                x = -900;
                y -= 50;
            }
            else
            {
                x += 50;
            }
        }
    }
}
