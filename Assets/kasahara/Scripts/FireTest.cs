using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FireTest : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem fire;

    public void StartParticle()
    {
        fire.Play();
    }

    public void StopParticle()
    {
        fire.Stop();
    }
}
