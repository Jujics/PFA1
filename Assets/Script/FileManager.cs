using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class FileManager : MonoBehaviour, IDropHandler
{
    private Queue<GameObject> itemQueue = new Queue<GameObject>();
    public RectTransform[] slots; 
    public RectTransform door; 
    public float doorCooldown = 2f;
    public GameObject Door;
    public GameObject Aiguille;
    public enum ColorOfAtk{Blue,Red,Orange,Yellow}
    public ColorOfAtk colorOfDoor;
    private bool doorOpen = true;

    public GameObject Player;
    public int ScoreParAme;

    public void Start()
    {
        Player = GameObject.Find("Player");
    }
    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("Dropped");

        if (eventData.pointerDrag != null)
        {
            GameObject droppedItem = eventData.pointerDrag;
            if (itemQueue.Count < slots.Length)
            {
                itemQueue.Enqueue(droppedItem);
                droppedItem.GetComponent<CanvasGroup>().blocksRaycasts = false;
                SoulDataGrab Soul = droppedItem.GetComponent<SoulDataGrab>();
                if ((int)Soul.AmeData.colorOfDoor == (int)colorOfDoor)
                {
                    Soul.DieOnCorrectDoor = true;
                }
                else
                {
                    Soul.DieOnWrongDoor = true;
                }
                UpdateQueuePositions();
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
        if (doorOpen && itemQueue.Count > 0)
        {
            StartCoroutine(ProcessNextItem());
        }
        
        foreach (var item in itemQueue)
        {
            item.transform.SetParent(slots[index]);
            item.GetComponent<RectTransform>().anchoredPosition = slots[index].anchoredPosition;
            index++;
        }
    }

    private IEnumerator ProcessNextItem()
    {
        doorOpen = false;
        GameObject currentItem = itemQueue.Dequeue();
        currentItem.GetComponent<RectTransform>().anchoredPosition = door.anchoredPosition;
        //inclure ici le hadès pas content
        currentItem.SetActive(false);
        
        Debug.Log("Door is closed for " + doorCooldown + " seconds.");
        Door.GetComponent<Animator>().SetBool("IsOpen",false);
        Aiguille.GetComponent<Animator>().SetBool("IsClosed",true);
        yield return new WaitForSeconds(doorCooldown);
        Door.GetComponent<Animator>().SetBool("IsOpen",true);
        Aiguille.GetComponent<Animator>().SetBool("IsClosed",false);
        Debug.Log("Door is open.");

        doorOpen = true;
        
        UpdateQueuePositions();
    }
}