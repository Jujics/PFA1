using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
    public TutorialManager tutorialManager;

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
        // Example: Start tutorial on day 1, cycle 0
        if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
        }
        else if (CurrentDay == 1 && CurrentCycle == 0)
        {
            tutorialManager.StartTutorial();
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

        if (isSmallerThanL1 && isSmallerThanL2 && isSmallerThanL3 && isSmallerThanL4 && isSmallerThanL5)
        {
            //set end loose screen
            //set pause true
        }
        else
        {
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
    }

    private IEnumerator WaitUntilEndLevel()
    {
        yield return new WaitForSeconds(TimeUntilEndDay);
        //playertrust.score (la confiance du joueur)
        //set end of day screen
        //wait a little/wait for button click
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
            //set end win screen
        }
    }
}

