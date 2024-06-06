using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler, IDragHandler
{
   private RectTransform rectTransform;
   private CanvasGroup canvasGroup;
   private void Awake()
   {
      rectTransform = GetComponent<RectTransform>();
      canvasGroup = GetComponent<CanvasGroup>();
   }

   public void OnPointerDown(PointerEventData eventData)
   {
      Debug.Log("Onpointerdown");
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
