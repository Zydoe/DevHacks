using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    References references;
    public AudioClip chaseMusic;
    public AudioClip passiveMusic;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        references = GameObject.Find("References").GetComponent<References>();
    }

    // Update is called once per frame
    void Update()
    {
        if (references.dayNightManager.isDay) //during the day
        {
            audioSource.PlayOneShot(passiveMusic);
        }
        else if (!references.dayNightManager.isDay && references.chaseManager.playerInChase) //during the night
        {
            audioSource.PlayOneShot(chaseMusic);
        }
    }
}
