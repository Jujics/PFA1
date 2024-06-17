using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
    public Slider TimeTimer;
    private float TimeLeft;

    void OnEnable()
    {
        string soulName = AmeData.name;
        SoulAct[] acts = AmeData.Acts;
        SoulManager.ColorOfSoul color = AmeData.colorOfDoor;
        bool IsWhite = AmeData.IsWhite;
        PanelInfo = this.gameObject.transform.GetChild(0).gameObject;
        bool IsBig = AmeData.IsBig;


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

        StartCoroutine(CountTime());
    }

    void OnDisable()
    {
        if (!InErebe)
        {
            if (DieOutScreen && AmeData.IsWhite!)
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
    public IEnumerator CountTime()
    {
        float TimeLeft;

        if (AmeData.IsBig && AmeData.IsWhite)
        {
            TimeLeft = 23;
        }
        else if (AmeData.IsBig && !AmeData.IsWhite)
        {
            TimeLeft = 23;
        }
        else if (!AmeData.IsBig && AmeData.IsWhite)
        {
            TimeLeft = 32;
        }
        else if ((int)AmeData.colorOfDoor == 0)
        {
            TimeLeft = 1;
        }
        else
        {
            TimeLeft = 32;
        }

        TimeTimer.maxValue = TimeLeft;
        while (TimeLeft > 0)
        {
            if (InErebe || DieOutScreen)
            {
                yield return null;
                continue;
            }

            TimeLeft -= Time.deltaTime;
            TimeTimer.value = TimeLeft;
            yield return null; 
        }
        DieWhileWait = true;
        gameObject.SetActive(false);
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
