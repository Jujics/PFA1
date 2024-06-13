using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoulDataGrab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SoulManager AmeData;
    public TMP_Text Name;
    public TMP_Text[] Deed;
    public PlayerTrust _PlayerTrust;
    public bool InErebe;
    public bool DieOutScreen, DieWhileWait, DieOnWrongDoor, DieOnCorrectDoor;
    private GameObject PanelInfo;
    private float TimeLeft;

    void OnEnable()
    {
        string soulName = AmeData.name; 
        string[] ActsDesc = AmeData.Acts;
        int[] ActGrav = AmeData.ActGravity;
        SoulManager.ColorOfSoul color = AmeData.colorOfSoul;
        bool IsWhite = AmeData.IsWhite;
        PanelInfo = this.gameObject.transform.GetChild(0).gameObject;

        
        Name.text = soulName;
        int i = 0;
        while(i < 10)
        {
            Deed[i].text = ActsDesc[i];
            if (ActGrav[i] == 1)
            {
                Deed[i].color = new Color(255, 0, 0, 255); 
            }

            i++;
        }
    }

    void OnDisable()
    {
        if (!InErebe)
        {
            if (DieOutScreen)
            {
                _PlayerTrust.LooseScore(10);
            }
            else if(DieWhileWait)
            {
                _PlayerTrust.LooseScore(20);
            }
            else if(DieOnCorrectDoor)
            {
                _PlayerTrust.GainScore(25);
            }
            else if(DieOnWrongDoor)
            {
                _PlayerTrust.LooseScore(5);
            }
        }
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
