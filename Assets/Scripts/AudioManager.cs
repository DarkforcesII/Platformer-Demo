using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }

            GameObject managerObj = new GameObject("AudioManager");
            instance = managerObj.AddComponent<AudioManager>();
            return instance;
        }
    }

    // Initialized audio sources for manager
    #region
    private AudioSource musicSource;
    private AudioSource sfxSource;
    private AudioSource jumpSource;
    private AudioSource landSource;
    #endregion

    private void Awake()
    {
        musicSource = this.gameObject.AddComponent<AudioSource>();
        sfxSource = this.gameObject.AddComponent<AudioSource>();
        jumpSource = this.gameObject.AddComponent<AudioSource>();
        landSource = this.gameObject.AddComponent<AudioSource>();

        // Assigning audio mixer child to each audio source
        AudioMixer MasterMixer = Resources.Load<AudioMixer>("Master");
        string _MixerGroup1 = "Music";
        string _MixerGroup2 = "SFX";
        string _MixerGroup3 = "Jump";
        string _MixerGroup4 = "Land";
        musicSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup1)[0];
        sfxSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup2)[0];
        jumpSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup3)[0];
        landSource.outputAudioMixerGroup = MasterMixer.FindMatchingGroups(_MixerGroup4)[0];
    }

    // Play one shot audio clips
    public void PlaySFX(AudioClip audioClip, float volume, float pitch)
    {
        sfxSource.volume = volume;
        sfxSource.pitch = pitch;
        sfxSource.PlayOneShot(audioClip);
    }

    // Play loop source 1 with option to loop
    public void PlayMusicSource(AudioClip audioClip, float volume, bool loop)
    {
        musicSource.clip = audioClip;
        musicSource.volume = volume;
        musicSource.loop = loop;
        musicSource.Play();
    }
}
