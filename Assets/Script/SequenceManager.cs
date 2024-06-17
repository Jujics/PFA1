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



    void Start()
    {
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

    public void GoToEndScreenWin()
    {
        int ScoreAffiché = 0;
        EndScreenWin.SetActive(true);
        //ScoreAffiché = ScoreDuJour;         A prendre pour lier le score
        ScoreText.text += "\n" +ScoreAffiché;
    }

        public void GoToEndScreenLoose()
    {
        int ScoreAffiché = 0;
        EndScreenLoose.SetActive(true);
        //ScoreAffiché = ScoreDuJour;         A prendre pour lier le score
        ScoreText.text += "\n" +ScoreAffiché;
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

}
