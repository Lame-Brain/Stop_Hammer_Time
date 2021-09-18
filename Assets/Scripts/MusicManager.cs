using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioSource SFX, Music;
    public AudioClip beep, slap;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayBeep()
    {
        if(!SFX.isPlaying)
            SFX.PlayOneShot(beep);
    }

    public void PlaySlap()
    {
        if (!SFX.isPlaying)
            SFX.PlayOneShot(slap);
    }
}
