using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F))
        {
            LoadScene2();
        }
    }
    void LoadScene2()
    {
        Debug.Log("Loading Scene 2");
        SceneManager.LoadScene(2);
    }
}
