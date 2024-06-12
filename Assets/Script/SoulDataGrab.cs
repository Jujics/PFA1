using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulDataGrab : MonoBehaviour
{
    public SoulManager AmeData;
    
    void OnEnable()
    {
        string Name = AmeData.name;
        string[] ActsDesc = AmeData.Acts;
        int[] ActGrav = AmeData.ActGravity;
        SoulManager.ColorOfSoul color = AmeData.colorOfSoul;
        bool IsWhite = AmeData.IsWhite;
    }

    void Update()
    {
        
    }
}
