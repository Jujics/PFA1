using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CycleManager : MonoBehaviour
{
    public int CurrentDay;
    public IntScriptable MaxDays;
    public IntScriptable MaxCycle;
    public int CurrentCycle;
    public float TimeUntilEndDay;
    public SliderScript SliderScript;
    public BoatMovement BoatMovement;
    public UnityEvent OnLastCycle;
    public EnemiesDataHold EnemiesDataHold;
    public PlayerTrust PlayerTrust;
    public float PlayerTrustFloat;
    public GameObject[] OrderToDel;
    public AudioSource CharonIsComming;
    public WaitForUIButtons UiReset;
    public Slider[] Sliders;
    public SequenceManager sequenceManager;
    
    public TutorialManager tutorialManager;

    public Button CloseResultWinButton;

    void Start()
    {
        SliderScript.OnTimerEnd.AddListener(OnTimerEnd);
        SliderScript.OnBoatStartTime.AddListener(OnBoatStartTime);
        StartNewCycle();
    }

    public void OnTimerEnd()
    {
        CurrentCycle++;
        if (CurrentCycle < MaxCycle.Value)
        {
            if (CurrentCycle == MaxCycle.Value - 1)
            {
                LastCycle();
            }
            StartNewCycle();
            
        }
    }

    public void OnBoatStartTime()
    {
        CharonIsComming.Play();
        BoatMovement.StartMovement();
    }

    public void StartNewCycle()
    {
        SliderScript.StartSlider();
        CheckForTutorial();
    }

    public void LastCycle()
    {
        //make the bell sound
        StartCoroutine(WaitUntilEndLevel());
    }

    private void CheckForTutorial()
    {
        if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial(0); 
        }
        else if (CurrentDay == 1 && CurrentCycle == 1)
        {
            tutorialManager.StartTutorial(1); 
        }
        else if (CurrentDay == 1 && CurrentCycle == 2)
        {
            tutorialManager.StartTutorial(2); 
        }
        else if (CurrentDay == 1 && CurrentCycle == 4)
        {
            tutorialManager.StartTutorial(3); 
        }
        else if (CurrentDay == 2 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial(4); 
        }
        else if (CurrentDay == 3 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial(5); 
        }
        else if (CurrentDay == 3 && CurrentCycle == 1)
        {
            tutorialManager.StartTutorial(6); 
        }
        else if (CurrentDay == 3 && CurrentCycle == 3)
        {
            tutorialManager.StartTutorial(7); 
        }
        else if (CurrentDay == 3 && CurrentCycle == 4)
        {
            tutorialManager.StartTutorial(8); 
        }
        else if (CurrentDay == 4 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial(9); 
        }
        else if (CurrentDay == 4 && CurrentCycle == 1)
        {
            tutorialManager.StartTutorial(10); 
        }
        else if (CurrentDay == 5 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial(11); 
        }
    }

    public void ScoreCompare()
    {
        float[] ListData1;
        float[] ListData2;
        float[] ListData3;
        float[] ListData4;
        float[] ListData5;
        ListData1 = EnemiesDataHold.EnemyOne;
        ListData2 = EnemiesDataHold.EnemyTwo;
        ListData3 = EnemiesDataHold.EnemyThree;
        ListData4 = EnemiesDataHold.EnemyFour;
        ListData5 = EnemiesDataHold.EnemyFive;
        SmallerOne(ListData1, ListData2, ListData3, ListData4, ListData5);
    }

    public void SmallerOne(float[] L1, float[] L2, float[] L3, float[] L4, float[] L5)
    {
        bool isSmallerThanL1 = PlayerTrustFloat < L1[CurrentDay - 1];
        bool isSmallerThanL2 = PlayerTrustFloat < L2[CurrentDay - 1];
        bool isSmallerThanL3 = PlayerTrustFloat < L3[CurrentDay - 1];
        bool isSmallerThanL4 = PlayerTrustFloat < L4[CurrentDay - 1];
        bool isSmallerThanL5 = PlayerTrustFloat < L5[CurrentDay - 1];

        switch (CurrentDay)
        {
            case 1:
                if (isSmallerThanL1)
                {
                    sequenceManager.GoToEndScreenLoose(PlayerTrust.Score);
                }
                else
                {
                    sequenceManager.GoToEndScreenWin(PlayerTrust.Score);
                }
                break;
            case 2:
                if (isSmallerThanL2)
                {
                    sequenceManager.GoToEndScreenLoose(PlayerTrust.Score);
                }
                else
                {
                    sequenceManager.GoToEndScreenWin(PlayerTrust.Score);
                }
                break;
            case 3:
                if (isSmallerThanL3)
                {
                    sequenceManager.GoToEndScreenLoose(PlayerTrust.Score);
                }
                else
                {
                    sequenceManager.GoToEndScreenWin(PlayerTrust.Score);
                }
                break;
            case 4:
                if (isSmallerThanL4)
                {
                    sequenceManager.GoToEndScreenLoose(PlayerTrust.Score);
                }
                else
                {
                    sequenceManager.GoToEndScreenWin(PlayerTrust.Score);
                }
                break;
            case 5:
                if (isSmallerThanL5)
                {
                    sequenceManager.GoToEndScreenLoose(PlayerTrust.Score);
                }
                else
                {
                    sequenceManager.GoToEndScreenWin(PlayerTrust.Score);
                }
                break;
        }
        if (CurrentDay == 1)
        {
            OrderToDel[0].SetActive(false);
        }
        else if (CurrentDay == 2)
        {
            OrderToDel[1].SetActive(false);
        }
        else if (CurrentDay == 3)
        {
            OrderToDel[2].SetActive(false);
        }
        else if (CurrentDay == 4) 
        {
            OrderToDel[3].SetActive(false); 
        }
        else if (CurrentDay == 5)
        { 
            OrderToDel[4].SetActive(false);
        }
        else if (CurrentDay == 6)
        {
            OrderToDel[5].SetActive(false);
        }
        
    }

    void Update()
    {
        float timeScale = BoatMovement.MaxTravelTime.Value * 5;
        if (CurrentDay == 1)
        {
            float val1 = Sliders[0].value; 
            float val2 = Sliders[1].value; 
            float val3 = Sliders[2].value; 
            float val4 = Sliders[3].value; 
            float val5 = Sliders[4].value;
            Sliders[0].value = Mathf.Lerp(val1,EnemiesDataHold.EnemyOne[0],timeScale);
            Sliders[1].value = Mathf.Lerp(val2,EnemiesDataHold.EnemyTwo[0],timeScale);
            Sliders[2].value = Mathf.Lerp(val3,EnemiesDataHold.EnemyThree[0],timeScale);
            Sliders[3].value = Mathf.Lerp(val4,EnemiesDataHold.EnemyFour[0],timeScale);
            Sliders[4].value = Mathf.Lerp(val5,EnemiesDataHold.EnemyFive[0],timeScale);
            
        }
        else if (CurrentDay == 2)
        {
            float val1 = Sliders[0].value; 
            float val2 = Sliders[1].value; 
            float val3 = Sliders[2].value; 
            float val4 = Sliders[3].value; 
            float val5 = Sliders[4].value;
            Sliders[0].value = Mathf.Lerp(val1,EnemiesDataHold.EnemyOne[1],timeScale);
            Sliders[1].value = Mathf.Lerp(val2,EnemiesDataHold.EnemyTwo[1],timeScale);
            Sliders[2].value = Mathf.Lerp(val3,EnemiesDataHold.EnemyThree[1],timeScale);
            Sliders[3].value = Mathf.Lerp(val4,EnemiesDataHold.EnemyFour[1],timeScale);
            Sliders[4].value = Mathf.Lerp(val5,EnemiesDataHold.EnemyFive[1],timeScale);
        }
        else if (CurrentDay == 3)
        {
            float val1 = Sliders[0].value; 
            float val2 = Sliders[1].value; 
            float val3 = Sliders[2].value; 
            float val4 = Sliders[3].value; 
            float val5 = Sliders[4].value;
            Sliders[0].value = Mathf.Lerp(val1,EnemiesDataHold.EnemyOne[2],timeScale);
            Sliders[1].value = Mathf.Lerp(val2,EnemiesDataHold.EnemyTwo[2],timeScale);
            Sliders[2].value = Mathf.Lerp(val3,EnemiesDataHold.EnemyThree[2],timeScale);
            Sliders[3].value = Mathf.Lerp(val4,EnemiesDataHold.EnemyFour[2],timeScale);
            Sliders[4].value = Mathf.Lerp(val5,EnemiesDataHold.EnemyFive[2],timeScale);
        }
        else if (CurrentDay == 4)
        {
            float val1 = Sliders[0].value; 
            float val2 = Sliders[1].value; 
            float val3 = Sliders[2].value; 
            float val4 = Sliders[3].value; 
            float val5 = Sliders[4].value;
            Sliders[0].value = Mathf.Lerp(val1,EnemiesDataHold.EnemyOne[3],timeScale);
            Sliders[1].value = Mathf.Lerp(val2,EnemiesDataHold.EnemyTwo[3],timeScale);
            Sliders[2].value = Mathf.Lerp(val3,EnemiesDataHold.EnemyThree[3],timeScale);
            Sliders[3].value = Mathf.Lerp(val4,EnemiesDataHold.EnemyFour[3],timeScale);
            Sliders[4].value = Mathf.Lerp(val5,EnemiesDataHold.EnemyFive[3],timeScale);
        }
        else if (CurrentDay == 5)
        {
            float val1 = Sliders[0].value; 
            float val2 = Sliders[1].value; 
            float val3 = Sliders[2].value; 
            float val4 = Sliders[3].value; 
            float val5 = Sliders[4].value;
            Sliders[0].value = Mathf.Lerp(val1,EnemiesDataHold.EnemyOne[4],timeScale);
            Sliders[1].value = Mathf.Lerp(val2,EnemiesDataHold.EnemyTwo[4],timeScale);
            Sliders[2].value = Mathf.Lerp(val3,EnemiesDataHold.EnemyThree[4],timeScale);
            Sliders[3].value = Mathf.Lerp(val4,EnemiesDataHold.EnemyFour[4],timeScale);
            Sliders[4].value = Mathf.Lerp(val5,EnemiesDataHold.EnemyFive[4],timeScale);
        }
    }

    private IEnumerator WaitUntilEndLevel()
    {
        yield return new WaitForSeconds(TimeUntilEndDay);
        bool HasWon = true;
        ScoreCompare();
        Time.timeScale = 0;
        new WaitForUIButtons(CloseResultWinButton);
        PlayerTrust.Score = 0;
        Time.timeScale = 1;
        if (CurrentDay < MaxDays.Value)
        {
            PlayerTrustFloat = PlayerTrust.Score;
            ScoreCompare();
            CurrentDay++;
            CurrentCycle = 0;
            StartNewCycle();
        }
        else
        {
            //set end screen
            sequenceManager.GoToEndGame();
        }
    }
}

