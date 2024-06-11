using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SequenceManager : MonoBehaviour
{
    public GameObject SettingsPanel;

    public GameObject MainMenuPanel;

    public GameObject EndScreen;

    public GameObject EndGame;

    public int[] BoatPassage;

    public int[] Enemies;

    public int DayNumber;



    // Start is called before the first frame update
    void Start()
    {
        SettingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToEndScreen()
    {
        EndScreen.SetActive(true);
    }

    public void GoToEndGame()
    {
        EndScreen.SetActive(false);
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
