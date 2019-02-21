using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScores : MonoBehaviour
{
    private const int TOP_SCORE_COUNT = 3;

    private List<PlayerScore> m_scores;

    [SerializeField] Text m_topScoreLabel01;
    [SerializeField] Text m_topScoreLabel02;
    [SerializeField] Text m_topScoreLabel03;

    void Start()
    {
        m_scores = new List<PlayerScore>();
        m_scores.Add(new PlayerScore() { playerName = "Pierre", score = 5000 });
        m_scores.Add(new PlayerScore() { playerName = "Pierre", score = 4000 });
        m_scores.Add(new PlayerScore() { playerName = "Pierre", score = 3000 });
        m_scores.Add(new PlayerScore() { playerName = "Pierre", score = 2000 });
        m_scores.Add(new PlayerScore() { playerName = "Pierre", score = 1000 });

        PlayerScore[] top3Scores = GetHighScores(TOP_SCORE_COUNT);

        if (top3Scores.Length == TOP_SCORE_COUNT)
        {
            if (m_topScoreLabel01)
                m_topScoreLabel01.text = "1st place: " + top3Scores[0].playerName + ", " + top3Scores[0].score + " points";
            if (m_topScoreLabel02)
                m_topScoreLabel02.text = "2nd place: " + top3Scores[1].playerName + ", " + top3Scores[1].score + " points";
            if (m_topScoreLabel03)
                m_topScoreLabel03.text = "3rd place: " + top3Scores[2].playerName + ", " + top3Scores[2].score + " points";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    PlayerScore[] GetHighScores(int topCount)
    {
        return m_scores.OrderByDescending(ps => ps.score).Take(topCount).ToArray();
    }

    public struct PlayerScore
    {
        public int score;
        public string playerName;
    }
}
