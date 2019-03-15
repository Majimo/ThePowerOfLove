using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Text text;

    public static PlayerScore[] highScores;
    string highScoreKey = "HighScore";

    private void Start()
    {
        text = GetComponent<Text>();

        resetScore();

        ScoreManager sm = new ScoreManager();
        sm.SetHigherScores();
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

    public static PlayerScore[] GetHigherScores()
    {
        ScoreManager sm = new ScoreManager();
        sm.SetHigherScores();
        return highScores;
    }

    private PlayerScore[] SetHigherScores()
    {
        highScores = new PlayerScore[3];
        for (int i = 0; i < highScores.Length; i++)
        {
            highScoreKey = "HighScore" + (i + 1).ToString();
            highScores[i] = new PlayerScore() { playerName = "Pierre", score = PlayerPrefs.GetInt(highScoreKey, 0) };
        }

        return highScores;
    }

    public struct PlayerScore
    {
        public int score;
        public string playerName;
    }
}
