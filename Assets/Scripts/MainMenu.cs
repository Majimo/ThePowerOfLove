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
}
