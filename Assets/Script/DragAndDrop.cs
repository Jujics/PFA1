using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject Boat;
    public Transform MainCan;
    public GameObject Ame;
    public GameObject PreviousSlot; 
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private SoulDataGrab _soulDataGrab;
    private Animator animator;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        _soulDataGrab = GetComponent<SoulDataGrab>();
        animator = Ame.GetComponent<Animator>(); 
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
        animator.SetBool("Grab", true); 
        // Debug.Log("OnPointerDown");
        _soulDataGrab.DieOutScreen = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
        PreviousSlot = transform.parent.gameObject;
        BoatPlacementSoul boatPlacementSoul = FindObjectOfType<BoatPlacementSoul>();
        for (int i = 0; i < boatPlacementSoul.OpenSlot.Length; i++)
        {
            if (boatPlacementSoul.OpenSlot[i] == gameObject)
            {
                boatPlacementSoul.OpenSlot[i] = null;
                transform.SetParent(MainCan);
                break;
            }
        }

        transform.SetParent(MainCan.transform);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        eventData.pointerDrag.GetComponent<Animator>().SetBool("Grab", false);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("Dragging");
        rectTransform.anchoredPosition += eventData.delta;
    }
}