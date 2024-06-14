using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoulDataGrab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SoulManager AmeData;
    public SoulScoreData ScoreData;
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
        SoulAct[] acts = AmeData.Acts;
        SoulManager.ColorOfSoul color = AmeData.colorOfDoor;
        bool IsWhite = AmeData.IsWhite;
        PanelInfo = this.gameObject.transform.GetChild(0).gameObject;


        Name.text = soulName;
        for (int i = 0; i < acts.Length; i++)
        {
            if(i >= Deed.Length)
                break;

            Deed[i].text = acts[i].Desc;
            if (acts[i].Gravity == 1)
            {
                Deed[i].color = new Color(255, 0, 0, 255);
            }
        }
    }

    void OnDisable()
    {
        if (!InErebe)
        {
            if (DieOutScreen)
            {
                
                _PlayerTrust.LooseScore(ScoreData.DieOutScreen);
            }
            else if (DieWhileWait)
            {
                _PlayerTrust.LooseScore(ScoreData.DieWhileWait);
            }
            else if (DieOnCorrectDoor)
            {
                _PlayerTrust.GainScore(ScoreData.DieOnCorrectDoor);
            }
            else if (DieOnWrongDoor)
            {
                _PlayerTrust.LooseScore(ScoreData.DieOnWrongDoor);
            }
        }
    }

    //private IEnumerator CountTime()
    //{
    //    
    //        int TimeLeft = 1;
    //    while (TimeLeft > 0)
    //    {
    //        while (InErebe! && DieOutScreen)
    //        {
    //        
    //        }
    //    }
    //    
    //        
    //}

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
