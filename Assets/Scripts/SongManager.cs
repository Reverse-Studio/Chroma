using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SongManager : MonoBehaviour
{

    public static SongManager Instance = null;
    public AudioClip stage1BGM;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void Playsingle(AudioClip clip, Vector3 position, float volume = 1)
    {
        GameObject go = new GameObject("OneShotAudio" + DateTime.Now.ToString("yyyyMMddhhmmssf"));
        AudioSource source = go.AddComponent<AudioSource>();

        go.transform.position = position;

        source.spatialBlend = 1;
        source.clip = clip;
        source.volume = volume;

        if (volume > 1)
        {
            source.minDistance = volume;
        }

        source.Play();
        Destroy(go, clip.length);
    }
}
