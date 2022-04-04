using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;

    public bool loop;

    public enum Type {
    
        MUSIC,
        FX
    
    };

    public Type type;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public void Awake()
    {
        source.loop = loop;
    }
}