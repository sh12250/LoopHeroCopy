using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false;
    private float startTime = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audioSource.isPlaying)
        {
            if (!isPlaying)
            {
                isPlaying = true;
                startTime = Time.time;
            }

            if (Time.time - startTime >= audioSource.clip.length)
            {
                isPlaying = false;
                AudioManager.instance.PlayMusic_Basic();
            }
        }
        else
        {
            isPlaying = false;
        }
    }
}
