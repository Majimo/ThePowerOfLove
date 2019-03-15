using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public bool playerInZone;
    public string titleScreen;

    string highScoreKey = "HighScore";

    void Start()
    {
        playerInZone = false;        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && playerInZone)
        {
            // Update HighScore & Load TitleScreen

            for (int i = 0; i < ScoreManager.highScores.Length; i++)
            {
                highScoreKey = "HighScore" + (i + 1).ToString();
                ScoreManager.highScores[i].score = PlayerPrefs.GetInt(highScoreKey, 0);
                
                if ((ScoreManager.score + TimeManager.GetTimeScore()) > ScoreManager.highScores[i].score)
                {
                    int temp = ScoreManager.highScores[i].score;
                    PlayerPrefs.SetInt(highScoreKey, ScoreManager.score + TimeManager.GetTimeScore());
                    PlayerPrefs.Save();
                    ScoreManager.score = temp - TimeManager.GetTimeScore();
                }
            }

            SceneManager.LoadScene(titleScreen);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerInZone = false;
        }
    }
}
