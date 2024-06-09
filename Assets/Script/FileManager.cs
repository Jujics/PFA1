using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FileManager : MonoBehaviour, IDropHandler
{
    private Queue<GameObject> itemQueue = new Queue<GameObject>();
    public RectTransform[] slots; 
    public RectTransform door; 
    public float doorCooldown = 2f;

    private bool doorOpen = true;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped");

        if (eventData.pointerDrag != null)
        {
            GameObject droppedItem = eventData.pointerDrag;
            if (itemQueue.Count < slots.Length)
            {
                itemQueue.Enqueue(droppedItem);
                UpdateQueuePositions();
                droppedItem.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            else
            {
                Debug.Log("Queue is full");
            }
        }
    }

    private void UpdateQueuePositions()
    {
        int index = 0;
        foreach (var item in itemQueue)
        {
            item.transform.SetParent(slots[index]);
            item.GetComponent<RectTransform>().anchoredPosition = slots[index].anchoredPosition;
            index++;
        }

        if (doorOpen && itemQueue.Count > 0)
        {
            StartCoroutine(ProcessNextItem());
        }
    }

    private IEnumerator ProcessNextItem()
    {
        doorOpen = false;
        GameObject currentItem = itemQueue.Dequeue();
        currentItem.GetComponent<RectTransform>().anchoredPosition = door.anchoredPosition;
        currentItem.SetActive(false);
        Debug.Log("Door is closed for " + doorCooldown + " seconds.");
        yield return new WaitForSeconds(doorCooldown);
        Debug.Log("Door is open.");

        doorOpen = true;
        UpdateQueuePositions();
    }
}