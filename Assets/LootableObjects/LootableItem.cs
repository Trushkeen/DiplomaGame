using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableItem : MonoBehaviour
{
    public Loot Loot;

    [Header("Voiceover")]
    public bool HasVOClip = false;
    public AudioSource VOSource;
    public AudioClip VOClip;

    private void Start()
    {
        VOSource = GameObject.FindGameObjectWithTag("VOPlayer").GetComponent<AudioSource>();
    }

    public void PlayVOClip()
    {
        if (VOClip != null)
        {
            VOSource.clip = VOClip;
            VOSource.Play();
        }
        else
        {
            print("Set voiceover clip to quest object: " + gameObject.name);
        }
    }
}
