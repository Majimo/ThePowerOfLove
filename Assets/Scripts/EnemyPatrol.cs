using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hitWall;

    private bool atEdge;
    public Transform edgeCheck;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hitWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hitWall || !atEdge)
        {
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            enemy.velocity = new Vector2(moveSpeed, enemy.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            enemy.velocity = new Vector2(-moveSpeed, enemy.velocity.y);
        }
    }
}
