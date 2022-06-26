using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSaver : MonoBehaviour
{
    public InputField nameInputField;

    private List<HighScoreEntry> scores;

    public void ReadStringInput(string stringInput)
    {
        if (!nameInputField.readOnly)
        {
            string entryName = stringInput;
            string entryTimeText = GameObject.Find("seconds survived").GetComponent<Text>().text;
            float entryTime = float.Parse(entryTimeText);

            AddNewScore(entryName, entryTime);
            SaveScore();
            nameInputField.readOnly = true;
        }
    }

    void SaveScore()
    {
        XMLManager.instance.SaveScores(scores);
    }

    void AddNewScore(string entryName, float entryTime)
    {
        scores = XMLManager.instance.LoadScores();
        HighScoreEntry scoreEntry = new HighScoreEntry { name = entryName.ToUpper(), time = entryTime };
        scores.Add(scoreEntry);
    }
}
