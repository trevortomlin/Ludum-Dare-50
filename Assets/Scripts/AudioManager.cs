using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public Sound[] sounds;

    public void SetMusicVol()
    {
        float musicSliderVal = GameObject.Find("Music Slider").GetComponent<Slider>().value;

        //Debug.Log(musicSliderVal);

        foreach (Sound s in sounds)
        {

            if (s.type == Sound.Type.MUSIC)
            {
                //Debug.Log(s.name);
                s.source.volume = musicSliderVal;
                //Debug.Log(s.volume);

            }

        }
    }

    public void SetFXVol()
    {

        float fxSliderVal = GameObject.Find("FX Slider").GetComponent<Slider>().value;
        foreach (Sound s in sounds)
        {

            if (s.type == Sound.Type.FX)
            {

                s.source.volume = fxSliderVal;

            }

        }

    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }

    }

    public void Start()
    {
        Play("TitleScreen");
    }

    public void Play(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();

    }

    public void Stop(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();

    }

    public void StopAll()
    {

        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }

    }
}