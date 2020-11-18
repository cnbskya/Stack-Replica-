using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;
    public int perfectCount;

    public AudioClip[] sounds;
    void Start()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStartGameSoundActive()
    {
        audioSource.PlayOneShot(sounds[0], 0.2f);
    }

    public void PlayDropCube()
    {
        audioSource.PlayOneShot(sounds[1], 1);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(sounds[2], 1);
    }

    public void PlayPerfectTime()
    {
        if (perfectCount == 0)
        {
            audioSource.PlayOneShot(sounds[3], 1);
            perfectCount++;
        }else if (perfectCount == 1)
        {
            audioSource.PlayOneShot(sounds[4], 1);
            perfectCount++;
        }else if (perfectCount == 2)
        {
            audioSource.PlayOneShot(sounds[5], 1);
            perfectCount++;
        }else if (perfectCount == 3)
        {
            audioSource.PlayOneShot(sounds[6], 1);
            perfectCount++;
        }else if (perfectCount == 4)
        {
            audioSource.PlayOneShot(sounds[7], 1);
            perfectCount++;
        }else if (perfectCount == 5)
        {
            audioSource.PlayOneShot(sounds[8], 1);
            perfectCount++;
        }else if (perfectCount == 6)
        {
            audioSource.PlayOneShot(sounds[8], 1);
            perfectCount++;
        }
    }
}