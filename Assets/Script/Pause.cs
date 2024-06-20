using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool IsPaused = false;
    public int TutoPannel;
    public GameObject[] TutoPannelList;
    public GameObject PauseMenu;
    public IEnumerator OnPause(bool OnTuto)
    {
        if(OnTuto)
        {
            while (IsPaused)
            {
                Time.timeScale = 0;
                TutoPannelList[0].SetActive(true);
            }

            Time.timeScale = 1;
        }
        else
        {
            while (IsPaused)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }

            Time.timeScale = 1;
        }
    }
}
