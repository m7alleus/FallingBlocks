using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;

    public float secondsSurvived;

    void Start()
    {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    void Update()
    {
        if (gameOver)
        {
            // Focus on text-input asking for user's name
            InputField inputField = FindObjectOfType<InputField>();
            inputField.Select();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Game
                SceneManager.LoadScene(1);
            }
            else if(Input.GetKeyDown(KeyCode.Escape))
            {
                // Menu
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        secondsSurvived = Mathf.Round(Time.timeSinceLevelLoad * 100.0f) / 100.0f;
        secondsSurvivedUI.text = secondsSurvived.ToString();
        gameOver = true;
    }
}
