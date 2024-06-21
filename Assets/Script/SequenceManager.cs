using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SequenceManager : MonoBehaviour
{
    public GameObject SettingsPanel;

    public GameObject MainMenuPanel;

    public GameObject EndScreenWin;

    public GameObject EndScreenLoose;

    public GameObject EndGame;

    public int[] BoatPassage;

    public int[] Enemies;

    public int DayNumber;

    public TMP_Text ScoreText;
    private TMP_Text OriginalText;

    public GameObject HadesHappyFeedBackTarget;
    public GameObject HadesAngryFeedBackTarget;

    void Start()
    {
        OriginalText.text = ScoreText.text;
        HadesHappyFeedBackTarget = GameObject.Find("Game/HadesHappyFeedBackTarget");
        HadesHappyFeedBackTarget.SetActive(false);
        HadesAngryFeedBackTarget = GameObject.Find("Game/HadesAngryFeedBackTarget");
        HadesAngryFeedBackTarget.SetActive(false);
        if (SettingsPanel != null)
        SettingsPanel.SetActive(false);
    }


    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToEndScreenWin(int playertrust)
    {
        EndScreenWin.SetActive(true);
        ScoreText.text = OriginalText + "\n" +playertrust;
    }

        public void GoToEndScreenLoose(int playertrust)
    {
        EndScreenLoose.SetActive(true);
        //ScoreAffiché = ScoreDuJour;         A prendre pour lier le score
        ScoreText.text = OriginalText + "\n" +playertrust;
    }

    public void CloseResultWin()
    {
        EndScreenWin.SetActive(false);
    }

    public void GoToEndGame()
    {
        EndScreenWin.SetActive(false);
        EndGame.SetActive(true);
    }

    public void OpenSettings()
    {
        SettingsPanel.SetActive(true);
        MainMenuPanel.SetActive(false);
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
        MainMenuPanel.SetActive(true); 
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }



    public void StartSpicifiedCoroutine(int n)
    {
        if(n == 1)
        StartCoroutine(HadesHappy());
        else if(n == 0)
        StartCoroutine(HadesAngry());
    }

    public IEnumerator HadesHappy()
    {
        HadesHappyFeedBackTarget.SetActive(true);
        yield return new WaitForSeconds(2);
        HadesHappyFeedBackTarget.SetActive(false);
    }

    public IEnumerator HadesAngry()
    {
        HadesAngryFeedBackTarget.SetActive(true);
        yield return new WaitForSeconds(2);
        HadesAngryFeedBackTarget.SetActive(false);
    }

}
