 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrust : MonoBehaviour
{
    public Slider Slider;
    public int MaxValue;
    public int Score;

    void Start()
    {
        Slider.maxValue = MaxValue;
        Score = 0;
    }

    public void GainScore(int Gain)
    {
        Score += Gain;
        UpdateScore();
    }

    public void LooseScore(int Loss)
    {
        Score -= Loss;
        UpdateScore();
    }

    public void UpdateScore()
    {
        Slider.value = Score;
    }

    public void EndOfDayCheck()
    {
        
    }
}
