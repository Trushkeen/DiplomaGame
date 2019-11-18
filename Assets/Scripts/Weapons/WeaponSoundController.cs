using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSoundController : MonoBehaviour
{
    public AudioSource Emitter;

    public AudioClip[] Shot;
    public AudioClip ClipIn;
    public AudioClip ClipOut;
    public AudioClip FullReloading;
    public AudioClip[] ShellDrop;
    public AudioClip Arming;
    public AudioClip WeaponDrop;

    public void PlayShot()
    {
        Emitter.clip = Shot[Random.Range(0, Shot.Length)];
        Emitter.Play();
    }

    public void PlayClipIn()
    {
        Emitter.clip = ClipIn;
        Emitter.Play();
    }

    public void PlayClipOut()
    {
        Emitter.clip = ClipOut;
        Emitter.Play();
    }
}
