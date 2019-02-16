using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public int pointsToAdd;

    public AudioSource coinPickUpSound;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() == null)
        {
            return;
        }
        ScoreManager.AddPoints(pointsToAdd);

        coinPickUpSound.Play();

        Destroy(gameObject);
    }
}
