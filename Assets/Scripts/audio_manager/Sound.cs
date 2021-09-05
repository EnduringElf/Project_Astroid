using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

[Serializable]
public class Sound
{
    public string name;

    public AudioClip audioClip;

    [Range(0f,1f)]
    public float Volume;
    [Range(0f, 1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;




}
