using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public FloatScriptable TotalTime;
    public FloatScriptable BoatStartTime;
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
        if (!Pause && _currentTime < TotalTime.Value)
        {
            _currentTime += Time.deltaTime;
            if (!EventTriggered && _currentTime > BoatStartTime.Value)
            {
                OnBoatStartTime.Invoke();
                EventTriggered = true;
            }

            if (_currentTime >= TotalTime.Value)
            {
                _currentTime = TotalTime.Value;
                Pause = true;
                OnTimerEnd.Invoke();
            }
        }

        Slider.value = 100 * _currentTime / TotalTime.Value;
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        EventTriggered = false;
        _currentTime = 0;
    }
}
