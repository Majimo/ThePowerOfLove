using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public bool playerInZone;
    public string titleScreen;

    void Start()
    {
        playerInZone = false;        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && playerInZone)
        {
            // Update HighScore & Load TitleScreen
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
