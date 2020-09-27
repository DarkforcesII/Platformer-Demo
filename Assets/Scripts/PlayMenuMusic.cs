using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuMusic : MonoBehaviour
{
    public AudioClip[] musicClips;

    public AudioSource musicSource;

    private void Awake()
    {
        StartCoroutine(PlayMusicClips());
    }

    IEnumerator PlayMusicClips()
    {
        while (true)
        {
            musicSource.PlayOneShot(musicClips[Random.Range(0, musicClips.Length)]);
            yield return new WaitForSecondsRealtime(musicClips[0].length);
        }
    }
}
