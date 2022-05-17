using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip lick;
    [SerializeField] private AudioClip damage;
    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void LickSound()
    {
        _audioSource.clip = lick;
        _audioSource.Play();
    }

    public void DamageSound()
    {
        _audioSource.clip= damage;
        _audioSource.Play();
    }
}