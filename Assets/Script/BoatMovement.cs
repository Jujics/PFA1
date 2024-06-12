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
    public GameObject[] DayfiveList;
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
        Pause = false;
    }

    private void Reset()
    {
        CurrentTravelTime = 0;
    }
}
