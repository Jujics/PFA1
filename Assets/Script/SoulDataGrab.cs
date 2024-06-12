using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoulDataGrab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SoulManager AmeData;
    private GameObject PanelInfo;
    
    void OnEnable()
    {
        string Name = AmeData.name;
        string[] ActsDesc = AmeData.Acts;
        int[] ActGrav = AmeData.ActGravity;
        SoulManager.ColorOfSoul color = AmeData.colorOfSoul;
        bool IsWhite = AmeData.IsWhite;
        PanelInfo = this.gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PanelInfo.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PanelInfo.SetActive(false);
    }
}
