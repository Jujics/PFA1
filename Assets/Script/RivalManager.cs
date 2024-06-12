using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RivalManager : MonoBehaviour
{
    public int ValueOnStart;

    void Start()
    {
        Slider Slider = GetComponentInChildren<Slider>();
        Slider.maxValue = 100;
        Slider.value = ValueOnStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
