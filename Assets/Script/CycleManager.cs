using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CycleManager : MonoBehaviour
{
    public int CurrentDay;
    public int MaxDays;
    public int MaxCycle;
    public int CurrentCycle;
    public float TimeUntilEndDay;
    public SliderScript SliderScript;
    public BoatMovement BoatMovement;
    public UnityEvent OnLastCycle;
    
    void Start()
    {
        SliderScript.OnTimerEnd.AddListener(OnTimerEnd);
        SliderScript.OnBoatStartTime.AddListener(OnBoatStartTime);
        StartNewCycle();
    }


    public void OnTimerEnd()
    {
        CurrentCycle++;
        if (CurrentCycle < MaxCycle)
        {
            if (CurrentCycle == MaxCycle - 1) 
            {
                LastCycle();
            }
            StartNewCycle();
        }
    }

    public void OnBoatStartTime()
    {
        BoatMovement.StartMovement();
    }

    public void StartNewCycle()
    {
        SliderScript.StartSlider();
    }

    public void LastCycle()
    {
        //make the bell sound
        StartCoroutine(WaitUntilEndLevel());
    }

    private IEnumerator WaitUntilEndLevel()
    {
        yield return new WaitForSeconds(TimeUntilEndDay);
        //add ui logic
        if (CurrentDay < MaxDays)
        {
            //compare score
            CurrentDay++;
            CurrentCycle = 0;
            StartNewCycle();
        }
        else
        {
            //set end screen
        }

    }
}
