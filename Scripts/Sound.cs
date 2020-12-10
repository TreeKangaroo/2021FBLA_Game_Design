using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    // this script creates a Sound class that stores the following values.

    public string title;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;

    public int priority;

    [HideInInspector]
    public AudioSource source;
}
