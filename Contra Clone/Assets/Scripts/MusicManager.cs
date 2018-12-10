using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musics;
    public AudioSource sauce;

    void Start()
    {
        int selectedSong = Random.Range(0, musics.Length);
        sauce.clip = musics[selectedSong];
        sauce.Play();
    }
}

//UwU

