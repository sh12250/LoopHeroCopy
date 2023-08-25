using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
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
                ReturnSelf();
            }
        }
        else
        {
            isPlaying = false;
            ReturnSelf();
        }
    }

    private void ReturnSelf()
    {
        SoundPlayerPool.ReturnSoundPlayer(this);
    }
}
