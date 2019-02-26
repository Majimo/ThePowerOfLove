using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeLeft;
    public static int timeScore;
    Text text;
    
    void Start()
    {
        timeLeft = 500.0f;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeScore = (int)(timeLeft * 10);
        text.text = ((int) (timeLeft * 10)) + "";
    }

    public static int GetTimeScore()
    {
        return timeScore;
    }
}
