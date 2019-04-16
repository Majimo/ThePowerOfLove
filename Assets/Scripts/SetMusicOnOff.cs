using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMusicOnOff : MonoBehaviour
{
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().PlayMusic();
    }
}
