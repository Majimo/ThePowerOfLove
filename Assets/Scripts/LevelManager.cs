using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private PlayerController player;

    private float gravityStore;

    public GameObject currentCheckPoint;
    public GameObject deathParticles;
    public GameObject respawnParticles;

    public int respawnDelay;

    public int deathPenalty;
    
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
        respawnDelay = 1;
    }

    public IEnumerator RespawnPlayerCo()
    {
        Instantiate(deathParticles, player.transform.position, player.transform.rotation);

        // Remove player GameObject & reset RigidBody2D
        player.gameObject.SetActive(false);
        player.GetComponent<Renderer>().enabled = false;
        gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0f;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        ScoreManager.AddPoints(-deathPenalty);

        // Wait for a certain amount of time
        yield return new WaitForSeconds(respawnDelay);

        // Restore player GameObject
        player.gameObject.SetActive(true);
        player.GetComponent<Renderer>().enabled = true;
        player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;

        player.transform.position = currentCheckPoint.transform.position;
        Instantiate(respawnParticles, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}
