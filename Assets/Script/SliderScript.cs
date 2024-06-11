using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public float TotalTime;
    public float BoatStartTime;
    public UnityEvent OnBoatStartTime;
    public UnityEvent OnTimerEnd;
    public Slider Slider;
    private float _currentTime;
    private bool EventTriggered = false;
    private bool Pause = true;
    
    public void StartSlider()
    {
        Reset();
        Pause = false;
        
    }

    void Update()
    {
        if (!Pause && _currentTime < TotalTime)
        {
            _currentTime += Time.deltaTime;
            if (!EventTriggered && _currentTime > BoatStartTime)
            {
                OnBoatStartTime.Invoke();
                EventTriggered = true;
            }

            if (_currentTime >= TotalTime)
            {
                _currentTime = TotalTime;
                Pause = true;
                OnTimerEnd.Invoke();
            }
        }

        Slider.value = 100 * _currentTime / TotalTime;
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        EventTriggered = false;
        _currentTime = 0;
    }
}
