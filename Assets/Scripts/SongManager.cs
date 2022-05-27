using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    public static SongManager Instance = null;

    public AudioClip BGM;

    public AudioSource Song;

    public float LowPitchRange = 0.95f;
    public float HighPitchRange = 1.05f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
    public void PlaySingle(AudioClip clip)
    {
        Song.clip = clip;
        Song.Play();
    }

    private void Start()
    {
        PlaySingle(BGM);
    }
}
