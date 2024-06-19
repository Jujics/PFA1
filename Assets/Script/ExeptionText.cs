using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExeptionText : MonoBehaviour
{
    public string[] ExceptionDayOne;
    public string[] ExceptionDayTwo;
    public string[] ExceptionDayThree;
    public string[] ExceptionDayFour;
    public string[] ExceptionDayFive;
    public TMP_Text[] TextZone;
    public GameObject CycleManagerHolder;
    private CycleManager CycleManager;

    void OnEnable()
    {
        CycleManager = CycleManagerHolder.GetComponent<CycleManager>();
        SetExceptionText();
    }

    void SetExceptionText()
    {
        int i = 0;
        int CDay = CycleManager.CurrentDay;
        Debug.Log(CDay);
        switch (CDay)
        {
            case 1:
                foreach (string Text in ExceptionDayOne)
                {
                    TextZone[i].text = Text;
                    i++;
                }
                break;
            case 2:
                foreach (string Text in ExceptionDayTwo)
                {
                    TextZone[i].text = Text;
                    i++;
                }
                break;
            case 3:
                foreach (string Text in ExceptionDayThree)
                {
                    TextZone[i].text = Text;
                    i++;
                }
                break;
            case 4:
                foreach (string Text in ExceptionDayFour)
                {
                    TextZone[i].text = Text;
                    i++;
                }
                break;
            case 5:
                foreach (string Text in ExceptionDayFive)
                {
                    TextZone[i].text = Text;
                    i++;
                }
                break;
        }
    }

    public void OnClicOpen()
    {
        this.gameObject.SetActive(true);
    }

    public void OnClicClose()
    {
        this.gameObject.SetActive(false);
    }
}

