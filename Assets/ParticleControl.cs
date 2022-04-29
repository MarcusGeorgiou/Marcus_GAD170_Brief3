using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    public ParticleSystem Ded;

    void OnEnable()
    {
        EventManager.OnDeath += PlayDeath;
    }

    void PlayDeath()
    {
        Ded.Play();
    }
}
