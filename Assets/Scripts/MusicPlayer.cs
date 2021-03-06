using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] musics;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.loop = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
    }
    private AudioClip GetRandomClip()
    {
        return musics[Random.Range(0, musics.Length)];
    }
}
