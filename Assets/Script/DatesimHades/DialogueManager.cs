using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text NameText;
    public TMP_Text Dialogue;
    public GameObject ChoisePannel;
    public ScptableText AllText;
    public int i = 0;
    public GameObject Hades;
    private bool End1 = false;
    private bool End2 = false;
    void Update()
    {
        NameText.text = AllText.Name[i];
        Dialogue.text = AllText.DialogueText[i];
        if (Input.GetMouseButtonDown(0))
        {
            i++;
            if (i == 25 && End2)
            {
                SceneManager.LoadScene(0);
            }
        }

        if (i == 3)
        {
            Hades.SetActive(true);
        }
        if (i == 13)
        {
            ChoisePannel.SetActive(true);
            Hades.SetActive(false);
        }

        if (i == 20 && End1)
        {
            SceneManager.LoadScene(0);
        }
        
    }

    public void OnClic1()
    {
        End1 = true;
        ChoisePannel.SetActive(false);
        Hades.SetActive(true);
    }
    public void OnClic2()
    {
        End2 = true;
        ChoisePannel.SetActive(false);
        Hades.SetActive(true);
        i = 20;
    }
}
