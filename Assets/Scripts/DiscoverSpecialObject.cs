using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscoverSpecialObject : MonoBehaviour
{
    public int pointsToAdd;
    public int stopPlayerDelay;
    public Text text;

    private float gravityStore;

    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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

        StartCoroutine(DisplayMessage());
        Debug.Log("Tu as découvert l'Epée du tragique amoureux !!!");
        text.text = "Tu as découvert l'Epée du tragique amoureux !!!";
        Debug.Log("Temps :" + Time.time);
    }

    public void DiscoverObjectMessage()
    {

        
    }

    public IEnumerator DisplayMessage()
    {
        player.StopPlayerMoves();

        yield return new WaitForSeconds(2);

        Debug.Log("Le temps est écoulé..." + Time.time);
        text.text = "";
        player.isAllowedToMove = true;

        Destroy(gameObject);
    }
}
