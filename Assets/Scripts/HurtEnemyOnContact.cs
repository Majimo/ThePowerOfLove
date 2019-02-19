using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnContact : MonoBehaviour
{
    public int damageOnContact;
    public float bounceOnEnemy;
    public Rigidbody2D parentRigidBody;

    void Start()
    {
        parentRigidBody = transform.parent.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealthManager>().takeDamage(damageOnContact);
            parentRigidBody.velocity = new Vector2(parentRigidBody.velocity.x, bounceOnEnemy);
        }
    }
}
