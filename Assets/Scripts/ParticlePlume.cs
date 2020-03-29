using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlume : MonoBehaviour
{
    private ParticleSystem _plumeParticleSystem;

    private void Awake()
    {
        _plumeParticleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        RaceManager.OnCirclePassed += GenerateRandomColor;
    }

    private void OnDestroy()
    {
        RaceManager.OnCirclePassed -= GenerateRandomColor;
    }

    private void GenerateRandomColor()
    {
        float alpha = _plumeParticleSystem.startColor.a;
        _plumeParticleSystem.startColor = new Color(Random.value, Random.value, Random.value, alpha);
    }
}
