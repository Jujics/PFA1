using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IdleZone : MonoBehaviour, IDropHandler
{
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            RectTransform droppedRectTransform = droppedObject.GetComponent<RectTransform>();

            if (droppedRectTransform != null)
            {
                Vector2 randomPosition = GetRandomPositionWithinBounds(droppedRectTransform);
                droppedRectTransform.anchoredPosition = randomPosition;
            }
        }
    }

    private Vector2 GetRandomPositionWithinBounds(RectTransform droppedRectTransform)
    {
        Vector2 zoneSize = _rectTransform.rect.size;
        Vector2 itemSize = droppedRectTransform.rect.size;
        float minX = _rectTransform.anchoredPosition.x - zoneSize.x / 2 + itemSize.x / 2;
        float maxX = _rectTransform.anchoredPosition.x + zoneSize.x / 2 - itemSize.x / 2;
        float minY = _rectTransform.anchoredPosition.y - zoneSize.y / 2 + itemSize.y / 2;
        float maxY = _rectTransform.anchoredPosition.y + zoneSize.y / 2 - itemSize.y / 2;
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector2(randomX, randomY);
    }
}