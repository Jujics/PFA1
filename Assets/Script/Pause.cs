using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public bool IsPaused = false;
    public bool OnTuto;
    public GameObject[] TutoPannelList;
    public GameObject PauseMenu;
    public Button ExitTutoButton;
    public TutorialManager tutorialManager;
    
    public IEnumerator OnPause()
    {
        if (OnTuto)
        {
            var waitForButton = new WaitForUIButtons(ExitTutoButton);
            while (IsPaused)
            {
                Time.timeScale = 0;
                yield return null; // Wait for the next frame
            }
            yield return waitForButton.Reset();
            Time.timeScale = 1;
        }
        else
        {
            while (IsPaused)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
                yield return null; // Wait for the next frame
            }

            Time.timeScale = 1;
        }
    }
}