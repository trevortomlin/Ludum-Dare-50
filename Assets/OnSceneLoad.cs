using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
    public string musicName;

    private void Start()
    {
        AudioManager.Instance.Play(musicName);
    }

    public void Stop()
    {

        AudioManager.Instance.StopAll();

    }
}
