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
    public CycleManager CycleManager;
    public GameObject CycleManagerHolder;
    
    void Start()
    {
        CycleManager = CycleManagerHolder.GetComponent<CycleManager>();
    }

    void Update()
    {
        int i = 0;
        if (CycleManager.CurrentDay == 1)
        {
            foreach (string Text in ExceptionDayOne)
            {
                TextZone[1].text = Text;
            }
        }
        if (CycleManager.CurrentDay == 2)
        {
            foreach (string Text in ExceptionDayTwo)
            {
                TextZone[1].text = Text;
            }
        }
        if (CycleManager.CurrentDay == 3)
        {
            foreach (string Text in ExceptionDayThree)
            {
                TextZone[1].text = Text;
            }
        }
        if (CycleManager.CurrentDay == 4)
        {
            foreach (string Text in ExceptionDayFour)
            {
                TextZone[1].text = Text;
            }
        }
        if (CycleManager.CurrentDay == 5)
        {
            foreach (string Text in ExceptionDayFive)
            {
                TextZone[1].text = Text;
            }
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
