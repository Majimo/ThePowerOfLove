using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string startLevel;
    public string highScoresTable;

    public void NewGame()
    {
        SceneManager.LoadScene(startLevel);
    }

    public void Scores()
    {
        SceneManager.LoadScene(highScoresTable);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /* public void UpdatePlayerHigherScore(int newScore)
    {
        if (newScore > playerProgress.highestScore)
        {
            playerProgress.highestScore = newScore;
            SavePlayerProgress();
        }
    }

    public int GetPlayerHigherScore()
    {
        return playerProgress.highestScore;
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();
        if (PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerProgress()
    {
        PlayerPrefs.SetInt("highestScore", playerProgress.highestScore);
    } */
}
