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

    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    private float volume = 1f;

    private void Awake()
    {
        instance = this;
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 1f);
        auidioSource = GetComponent<AudioSource>();
        auidioSource.volume = volume;

    }

    public void PlayCoinSounds()
    {
        randomCoinSound = Random.Range(0, 3);
        auidioSource.PlayOneShot(coinSoundClip[randomCoinSound]);
    }

    public void ChangeVolume()
    {
       
        volume += .1f;
        if (volume > 1f)
        {
            volume = 0f;
        }

        auidioSource.volume = volume;
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }


    public float GetVolume()
    {
        return volume;
    }

}
