using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public EventScript[] EventData;
    public CycleManager CycleManager;
    public GameObject DoorY1;
    public GameObject DoorY2;
    public GameObject DoorO1;
    public GameObject DoorO2;
    public GameObject DoorR1;
    public GameObject DoorR2;
    public ErebeScript ErebeManager;
    public int CurrentEvent;
    private int i = 0;
    private bool HasStarted = false;
    void Start()
    {
        int i = 0;
    }

    void Update()
    {
        if (EventData[i].DayOfTheEvent == CycleManager.CurrentDay && EventData[i].PassageOfTheEvent == CycleManager.CurrentCycle && HasStarted! )
        {
            HasStarted = true;
            StartCoroutine(CurrentEventManager());
            //if(day ==  3 && currentpassage == 3)
            //{here set tuto group8}
        }
    }

    IEnumerator CurrentEventManager()
    {
        
        if (EventData[i].IsCloseY1)
        {
            DoorY1.SetActive(false);
            DoorY1.GetComponent<Animator>().SetBool("InEvent",true);
            yield return new WaitForSeconds(EventData[i].ForHowLong);
            DoorY1.GetComponent<Animator>().SetBool("InEvent",false);
            DoorY1.SetActive(true);
        }
        else if (EventData[i].IsCloseY2)
        {
            DoorY2.SetActive(false);
            DoorY2.GetComponent<Animator>().SetBool("InEvent",true);
            yield return new WaitForSeconds(EventData[i].ForHowLong);
            DoorY2.GetComponent<Animator>().SetBool("InEvent",false);
            DoorY2.SetActive(true);   
        }
        else if (EventData[i].IsCloseO1)
        {
            DoorO1.SetActive(false);
            DoorO1.GetComponent<Animator>().SetBool("InEvent",true);
            yield return new WaitForSeconds(EventData[i].ForHowLong);
            DoorO1.GetComponent<Animator>().SetBool("InEvent",false);
            DoorO1.SetActive(true);
        }
        else if (EventData[i].IsCloseO2)
        {
            DoorO2.SetActive(false);
            DoorO2.GetComponent<Animator>().SetBool("InEvent",true);
            yield return new WaitForSeconds(EventData[i].ForHowLong);
            DoorO2.GetComponent<Animator>().SetBool("InEvent",false);
            DoorO2.SetActive(true);
        }
        else if (EventData[i].IsCloseR1)
        {
            DoorR1.SetActive(false);
            DoorR1.GetComponent<Animator>().SetBool("InEvent",true);
            yield return new WaitForSeconds(EventData[i].ForHowLong);
            DoorR1.GetComponent<Animator>().SetBool("InEvent",true);
            DoorR2.SetActive(true);
        }
        else if (EventData[i].IsCloseR2)
        {
            DoorR2.SetActive(false);
            DoorR2.GetComponent<Animator>().SetBool("InEvent",true);
            yield return new WaitForSeconds(EventData[i].ForHowLong);
            DoorR2.GetComponent<Animator>().SetBool("InEvent",true);
            DoorR2.SetActive(true);
        }
        else if (EventData[i].IsErebeClosed)
        {
            ErebeManager.isErebActive = false;
            yield return new WaitForSeconds(EventData[i].ForHowLong);
            ErebeManager.isErebActive = true;
        }
        bool OnNextPassage = false;
        while (OnNextPassage == false)
        { 
            if (EventData[i].PassageOfTheEvent != CycleManager.CurrentCycle)
            {
                OnNextPassage = true;
                HasStarted = false;
            }
        }
        i++;
    }
}
