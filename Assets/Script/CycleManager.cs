using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CycleManager : MonoBehaviour
{
    public int MaxCycle;
    public int CurrentCycle;
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
            if (CurrentCycle == MaxCycle - 1) ;
            {
                OnLastCycle.Invoke();
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
}
