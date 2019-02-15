using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMissileController : MonoBehaviour
{
    public Rigidbody2D heart;
    public float speed;
    public PlayerController player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;
    public int damagePoints;
    
    void Start()
    {
        heart = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
            speed = -speed;
    }

    void Update()
    {
        heart.velocity = new Vector2(speed, heart.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            /* Instantiate(enemyDeathEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            ScoreManager.AddPoints(pointsForKill); */
            collision.GetComponent<EnemyHealthManager>().takeDamage(damagePoints);
        }
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
