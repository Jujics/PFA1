using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class BoatMovement : MonoBehaviour
{
    public RectTransform rectTransform;
    public GameObject CycleManagerHolder;
    public float MaxTravelTime;
    public float CurrentTravelTime;
    public GameObject[] DayOneList;
    public GameObject[] DayTwoList;
    public GameObject[] DayThreeList;
    public GameObject[] DayFourList;
    public GameObject[] DayFiveList;
    private bool Pause = true;
    private Vector2 StartPosition, EndPosition;
    

    void Start()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
        StartPosition = new Vector2(Screen.width, rectTransform.anchoredPosition.y);
        EndPosition = new Vector2(-1225, rectTransform.anchoredPosition.y);
    }

    void Update()
    {
        if (!Pause && CurrentTravelTime < MaxTravelTime)
        {
            CurrentTravelTime += Time.deltaTime;
            if (CurrentTravelTime >= MaxTravelTime)
            {
                CurrentTravelTime = MaxTravelTime;
                Pause = true;
            }

            float t = CurrentTravelTime / MaxTravelTime;
            rectTransform.anchoredPosition = Vector2.Lerp(StartPosition, EndPosition, t);
        }
    }

    public void StartMovement()
    {
        CycleManager cycleManager;
        cycleManager = CycleManagerHolder.GetComponent<CycleManager>();
        Reset();
        switch (cycleManager.CurrentDay)
        {
            case 1 :
                switch (cycleManager.CurrentCycle)
                {
                    case 0:
                        DayOneList[0].SetActive(true);
                        break;
                    case 1:
                        DayOneList[0].SetActive(false);
                        DayOneList[1].SetActive(true);
                        break;
                    case 2:
                        DayOneList[1].SetActive(false);
                        DayOneList[2].SetActive(true);
                        break;
                    case 3:
                        DayOneList[2].SetActive(false);
                        DayOneList[3].SetActive(true);
                        break;
                    case 4:
                        DayOneList[3].SetActive(false);
                        DayOneList[4].SetActive(true);
                        break;
                }
                break;
            case 2 :
                switch (cycleManager.CurrentCycle)
                {
                    case 0:
                        DayTwoList[0].SetActive(true);
                        break;
                    case 1:
                        DayTwoList[0].SetActive(false);
                        DayTwoList[1].SetActive(true);
                        break;
                    case 2:
                        DayTwoList[1].SetActive(false);
                        DayTwoList[2].SetActive(true);
                        break;
                    case 3:
                        DayTwoList[2].SetActive(false);
                        DayTwoList[3].SetActive(true);
                        break;
                    case 4:
                        DayTwoList[3].SetActive(false);
                        DayTwoList[4].SetActive(true);
                        break;
                }
                break;
            case 3 :
                switch (cycleManager.CurrentCycle)
                {
                    case 0:
                        DayThreeList[0].SetActive(true);
                        break;
                    case 1:
                        DayThreeList[0].SetActive(false);
                        DayThreeList[1].SetActive(true);
                        break;
                    case 2:
                        DayThreeList[1].SetActive(false);
                        DayThreeList[2].SetActive(true);
                        break;
                    case 3:
                        DayThreeList[2].SetActive(false);
                        DayThreeList[3].SetActive(true);
                        break;
                    case 4:
                        DayThreeList[3].SetActive(false);
                        DayThreeList[4].SetActive(true);
                        break;
                }
                break;
            case 4 :
                switch (cycleManager.CurrentCycle)
                {
                    case 0:
                        DayFourList[0].SetActive(true);
                        break;
                    case 1:
                        DayFourList[0].SetActive(false);
                        DayFourList[1].SetActive(true);
                        break;
                    case 2:
                        DayFourList[1].SetActive(false);
                        DayFourList[2].SetActive(true);
                        break;
                    case 3:
                        DayFourList[2].SetActive(false);
                        DayFourList[3].SetActive(true);
                        break;
                    case 4:
                        DayFourList[3].SetActive(false);
                        DayFourList[4].SetActive(true);
                        break;
                }
                break;
            case 5 :
                switch (cycleManager.CurrentCycle)
                {
                    case 0:
                        DayFiveList[0].SetActive(true);
                        break;
                    case 1:
                        DayFiveList[0].SetActive(false);
                        DayFiveList[1].SetActive(true);
                        break;
                    case 2:
                        DayFiveList[1].SetActive(false);
                        DayFiveList[2].SetActive(true);
                        break;
                    case 3:
                        DayFiveList[2].SetActive(false);
                        DayFiveList[3].SetActive(true);
                        break;
                    case 4:
                        DayFiveList[3].SetActive(false);
                        DayFiveList[4].SetActive(true);
                        break;
                }
                break;
        }
    
            
        Pause = false;
    }

    private void Reset()
    {
        CurrentTravelTime = 0;
    }
}
