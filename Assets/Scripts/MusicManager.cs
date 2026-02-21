using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip chaseMusic;
    public AudioClip dayMusic;
    public AudioClip nightMusic;
    public GameObject musicPlayer;
    private AudioSource audioSource;
    void Awake()
    {
        audioSource = musicPlayer.GetComponent<AudioSource>();
    }
    public void PlayChaseMusic()
    {
        if (audioSource.clip != chaseMusic)
        {
            audioSource.clip = chaseMusic;
            audioSource.Play();
        }
    }
    public void PlayDayMusic()
    {
        if (audioSource.clip != dayMusic)
        {
            audioSource.clip = dayMusic;
            audioSource.Play();
        }
    }
    public void PlayNightMusic()
    {
        if (audioSource.clip != nightMusic)
        {
            audioSource.clip = nightMusic;
            audioSource.Play();
        }
    }
}
