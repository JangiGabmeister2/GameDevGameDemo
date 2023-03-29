using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance;
    public AudioSource musicAudio;
    public AudioClip[] music;
    public AudioSource sfxAudio;
    void Awake()
    {
        if (audioInstance != null && audioInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            audioInstance = this;
            DontDestroyOnLoad(gameObject);
            musicAudio.clip = music[Random.Range(0, music.Length)];
            musicAudio.Play();
        }
    }
}
