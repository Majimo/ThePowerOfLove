using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHighScores : MonoBehaviour
{
    private const int TOP_SCORE_COUNT = 3;

    private List<PlayerScore> highScores;

    public string mainMenu;

    [SerializeField] Text topScoreLabel01;
    [SerializeField] Text topScoreLabel02;
    [SerializeField] Text topScoreLabel03;

    void Start()
    {
        highScores = new List<PlayerScore>();
        highScores.Add(new PlayerScore() { playerName = "Pierre", score = ScoreManager.GetHigherScores()[0] });
        highScores.Add(new PlayerScore() { playerName = "Pierre", score = ScoreManager.GetHigherScores()[1] });
        highScores.Add(new PlayerScore() { playerName = "Pierre", score = ScoreManager.GetHigherScores()[2] });
    }
    
    void Update()
    {
        PlayerScore[] top3Scores = GetHighScores(TOP_SCORE_COUNT);

        if (top3Scores.Length == TOP_SCORE_COUNT)
        {
            if (topScoreLabel01)
                topScoreLabel01.text = "1st place: " + top3Scores[0].playerName + ", " + top3Scores[0].score + " points";
            if (topScoreLabel02)
                topScoreLabel02.text = "2nd place: " + top3Scores[1].playerName + ", " + top3Scores[1].score + " points";
            if (topScoreLabel03)
                topScoreLabel03.text = "3rd place: " + top3Scores[2].playerName + ", " + top3Scores[2].score + " points";
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(mainMenu);
        }

    }

    PlayerScore[] GetHighScores(int topCount)
    {
        return highScores.OrderByDescending(ps => ps.score).Take(topCount).ToArray();
    }

    public struct PlayerScore
    {
        public int score;
        public string playerName;
    }
}
