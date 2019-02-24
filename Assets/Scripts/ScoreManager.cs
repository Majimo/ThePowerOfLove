using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Text text;

    public static int[] highScores = new int[3];
    string highScoreKey = "HighScore";

    private void Start()
    {
        text = GetComponent<Text>();

        resetScore();

        for (int i = 0; i < highScores.Length; i++)
        {
            highScoreKey = "HighScore" + (i + 1).ToString();
            highScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
        }

        Debug.Log("Start :" + score);
    }

    private void Update()
    {
        if (score < 0)
            resetScore();

        text.text = "" + score;
    }

    public static void AddPoints(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public static void resetScore()
    {
        score = 0;
    }

    public static int[] GetHigherScores()
    {
        return highScores;
    }
}
