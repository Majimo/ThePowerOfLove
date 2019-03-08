using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms;
    public float moveAmount;
    public float startTimeBtwRoom = 0.25f;
    public float minX;
    public float maxX;
    public float minY;
    public LayerMask whatIsRoom;

    private int direction;
    private float timeBtwRoom;
    private bool stopGeneration;

    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        if (timeBtwRoom <= 0 && !stopGeneration)
        {
            Move();
            timeBtwRoom = startTimeBtwRoom;
        } else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    private void Move()
    {
        if (direction == 1 | direction == 2)
        {
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3) {
                    direction = 1;
                } else if (direction == 4) {
                    direction = 5;
                }
            } else
            {
                direction = 5;
            }
        } else if (direction == 3 | direction == 4)
        {
            if (transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);

            } else
            {
                direction = 5;
            }
        } else if (direction == 5)
        {
            if (transform.position.y > minY)
            {
                Collider2D previousRoom = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
                    //if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                    //{
                    //    roomDetection.GetComponent<RoomType>().RoomDestruction();

                    //    int randBottomRoom = Random.Range(1, 4);
                    //    if (randBottomRoom == 2)
                    //    {
                    //        randBottomRoom = 1;
                    //    }
                    //    Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    //}

                    Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            } else
            {
                stopGeneration = true;
            }
        }
    }
}
