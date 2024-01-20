using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [HideInInspector] public static SoundManager instance;
    [HideInInspector] public AudioSource auidioSource;
    [SerializeField] private AudioClip[] coinSoundClip;
     public AudioClip multipleCoinSoundClip;
     public AudioClip coinDropSoundClip;
     public AudioClip punchSoundClip;
     public AudioClip deathSoundClip;
    private int randomCoinSound;

    private void Awake()
    {
        instance = this;
       
    }


    private void Start()
    {
        auidioSource = GetComponent<AudioSource>();
    }


    public void PlayCoinSounds()
    {
        randomCoinSound = Random.Range(0, 3);
        auidioSource.PlayOneShot(coinSoundClip[randomCoinSound]);
    }
    
}
