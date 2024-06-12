using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RivalManager : MonoBehaviour
{
    public int ValueOnStart;
    public int MaxValue;

    void Start()
    {
        Slider Slider = GetComponentInChildren<Slider>();
        Slider.maxValue = MaxValue;
        Slider.value = ValueOnStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
