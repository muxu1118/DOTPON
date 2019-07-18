using UnityEngine;
using System.Collections;

public class RandomColorMaterial : MonoBehaviour
{
    private void Update()
    {
        Color rand = new Color(Random.value, Random.value, Random.value, 1.0f);
        ParticleSystem.MainModule par = GetComponent<ParticleSystem>().main;
        par.startColor = rand;
        
    }
}