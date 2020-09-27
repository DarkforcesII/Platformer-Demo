﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContainer : MonoBehaviour
{
    // makes it easier to access scripts
    public static AudioContainer audioContainer;

    public AudioSource jumpSource;
    public AudioSource musicSource1;
    public AudioSource musicSource2;
    public AudioSource musicSource3;
    public AudioSource musicSource4;
    public AudioSource sfxSource;
    public AudioSource uiSource;
    public AudioSource footStepSource;
    public AudioSource landSource;

    public AudioClip[] jumpClips;
    public AudioClip[] musicClips;
    public AudioClip coinSFX;
    public AudioClip[] uiClips;
    public AudioClip[] footStepClips;
    public AudioClip[] landClips;

    private bool playLandSfx;
    private float lerpSpeed1;
    private float lerpSpeed2;
    private float lerpSpeed3;
    private float lerpSpeed4;
    public float fadeInTime = 0.5f;

    // sfx methods
    #region
    public void PlayJumpClips()
    {
        jumpSource.clip = jumpClips[Random.Range(0, jumpClips.Length)];
        jumpSource.Play();
    }
    public void PlayCoinSFX()
    {
        sfxSource.clip = coinSFX;
        sfxSource.Play();
    }
    public void PointerEnterSFX()
    {
        uiSource.PlayOneShot(uiClips[0]);
    }
    public void PointerClickSFX()
    {
        uiSource.PlayOneShot(uiClips[1]);
    }
    public void PlayFootSteps()
    {
        footStepSource.pitch = Random.Range(0.85f, 1.1f);
        footStepSource.PlayOneShot(footStepClips[Random.Range(0, footStepClips.Length)]);
    }
    public void FootSetpsOnOff(float volume)
    {
        footStepSource.volume = volume;
    }
    public void PlayLandVoiceOver()
    {
        landSource.PlayOneShot(landClips[Random.Range(0, landClips.Length)]);
    }
    #endregion

    // music methods
    #region
    public void PlayMusicSource1()
    {
        musicSource1.clip = musicClips[0];
        musicSource1.loop = true;
        musicSource1.Play();
    }
    public void PlayMusicSource2(float volume)
    {
        musicSource2.clip = musicClips[1];
        musicSource2.loop = true;
        musicSource2.volume = volume;
        musicSource2.Play();
    }
    public void PlayMusicSource3(float volume)
    {
        musicSource3.clip = musicClips[2];
        musicSource3.volume = volume;
        musicSource3.loop = true;
        musicSource3.Play();
    }
    public void PlayMusicSource4()
    {
        musicSource4.clip = musicClips[3];
        musicSource4.Play();
    }

    // for web build
    public void StopMusicSource1()
    {
        musicSource1.Stop();
    }
    public void StopMusicSource2()
    {
        musicSource2.Stop();
    }
    public void StopMusicSource3()
    {
        musicSource3.Stop();
    }
    public void MusicSource2Vol(float volume)
    {
        musicSource2.volume = volume;
    }
    public void MusicSource3Vol(float volume)
    {
        musicSource3.volume = volume;
    }
    #endregion

    //first crossfade 
    #region
    public void StartCrossfadeOne()
    {
        StartCoroutine(FadeOutMusicSource1());
        StartCoroutine(FadeInMusicSource2());
    }
    // Fades out first loop source
    IEnumerator FadeOutMusicSource1()
    {
        yield return null;
        while (musicSource1.volume > 0)
        {
            lerpSpeed1 += Time.deltaTime;
            musicSource1.volume = Mathf.Lerp(1, 0, lerpSpeed1);
            //print(loopSource1.volume);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
    // Fades in 2nd music source
    IEnumerator FadeInMusicSource2()
    {
        yield return null;
        while (musicSource2.volume < 1.0f)
        {
            lerpSpeed2 += Time.deltaTime;
            musicSource2.volume = Mathf.Lerp(0, 1, lerpSpeed2);
            yield return new WaitForSecondsRealtime(fadeInTime);
        }
    }
    #endregion

    //2nd crossfade
    #region
    public void StartCrossfadeTwo()
    {
        StartCoroutine(FadeOutMusicSource2());
        StartCoroutine(FadeInMusicSource3());
    }
    // Fades out 2nd loop source
    IEnumerator FadeOutMusicSource2()
    {
        yield return null;
        while (musicSource2.volume > 0)
        {
            lerpSpeed3 += Time.deltaTime;
            musicSource2.volume = Mathf.Lerp(1, 0, lerpSpeed3);
            //print(loopSource1.volume);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
    // Fades in 3rd music source
    IEnumerator FadeInMusicSource3()
    {
        yield return null;
        while (musicSource3.volume < 1.0f)
        {
            lerpSpeed4 += Time.deltaTime;
            musicSource3.volume = Mathf.Lerp(0, 1, lerpSpeed4);
            yield return new WaitForSecondsRealtime(fadeInTime);
        }
    }
    #endregion
}
