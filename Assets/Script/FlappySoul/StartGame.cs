using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F))
        {
            LoadScene2();
        }
    }
    void LoadScene2()
    {
        // Ensure the scene index or name is correct
        Debug.Log("Loading Scene 2");
        SceneManager.LoadScene(2);
    }
}
