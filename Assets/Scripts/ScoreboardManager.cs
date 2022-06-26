using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardManager : MonoBehaviour
{
    private List<HighScoreEntry> scores;

    void Start()
    {
        scores = XMLManager.instance.LoadScores();
        scores.Sort((HighScoreEntry x, HighScoreEntry y) => y.time.CompareTo(x.time));

        // Only display 10 best scores
        for (int i = 0; i < Mathf.Min(10, scores.Count); i++)
        {
            HighScoreEntry score = scores[i];
            Transform scoreRow = transform.GetChild(i+1);
            scoreRow.transform.Find("Name").GetComponent<UnityEngine.UI.Text>().text = score.name;
            scoreRow.transform.Find("Score").GetComponent<UnityEngine.UI.Text>().text = score.time.ToString();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Menu
            SceneManager.LoadScene(0);
        }
    }
}
