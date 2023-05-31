using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField]
    private AudioClip scoreSound;
    [SerializeField]
    private AudioClip explosionSound;
    private AudioSource sound;

    private void Start()
    {
        sound = GameObject.Find("Sounds").GetComponent<AudioSource>();
    }

    public void PlayScore()
    {
        sound.clip = scoreSound;
        sound.Play();
    }
    public void PlayExplosion()
    {
        sound.clip = explosionSound;
        sound.Play();
    }
}
