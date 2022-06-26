using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    float secondsSurvived;
    bool gameOver;

    public float SecondsSurvived { get => secondsSurvived; set => secondsSurvived = value; }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
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
        SecondsSurvived = Mathf.Round(Time.timeSinceLevelLoad * 100.0f) / 100.0f;
        secondsSurvivedUI.text = SecondsSurvived.ToString();
        gameOver = true;
    }
}
