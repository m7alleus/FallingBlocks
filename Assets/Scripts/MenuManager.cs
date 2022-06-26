using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Game
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Highscore
            SceneManager.LoadScene(2);
        } 
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
