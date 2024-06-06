using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler, IDragHandler
{
   public int CurrentBoatPlacementId;
   public GameObject Boat;
   public GameObject MainCan;
   public IsPosOpen SetBackToFalse;
   private RectTransform rectTransform;
   private CanvasGroup canvasGroup;

   private void Start()
   {
      CurrentBoatPlacementId = 18;
   }

   private void Awake()
   {
      rectTransform = GetComponent<RectTransform>();
      canvasGroup = GetComponent<CanvasGroup>();
   }

   public void OnPointerDown(PointerEventData eventData)
   {
      Debug.Log("Onpointerdown");
      GameObject ZonePl = Boat.transform.GetChild(CurrentBoatPlacementId).gameObject;
      SetBackToFalse = ZonePl.GetComponent<IsPosOpen>();
      SetBackToFalse.isEmpty = false;
   }

   public void OnBeginDrag(PointerEventData eventData)
   {
      Debug.Log("OnBeginDrag");
      canvasGroup.blocksRaycasts = false;
   }

   public void OnEndDrag(PointerEventData eventData)
   {
      Debug.Log("OnEndDrag");
      canvasGroup.blocksRaycasts = true;
   }

   public void OnDrag(PointerEventData eventData)
   {
      Debug.Log("Draging");
      rectTransform.anchoredPosition += eventData.delta;
   }
}
