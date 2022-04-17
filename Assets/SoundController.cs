using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource Pew;

    void OnEnable()
    {
        EventManager.OnSpace += PlayShot;
    }

    void PlayShot()
    {
        Pew.Play();
    }
}
