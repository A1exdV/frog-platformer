using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSounds : MonoBehaviour
{
    [SerializeField] private AudioSource frog;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource swamp;

    [SerializeField] private Image state;

    [SerializeField] private Sprite on;

    [SerializeField] private Sprite off;
    public void SoundState()
    {
        if (frog.mute)
        {
            state.sprite = off;
        }
        else
        {
            state.sprite = on;
        }

        frog.mute = !frog.mute;
        music.mute = !music.mute;
        swamp.mute = !swamp.mute;
    }
}
