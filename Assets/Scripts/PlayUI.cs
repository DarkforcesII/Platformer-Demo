using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUI : MonoBehaviour
{
    public AudioClip uiClip;

    public AudioSource uiSource;

    public void PlaySFX()
    {
        uiSource.PlayOneShot(uiClip);
    }
}
