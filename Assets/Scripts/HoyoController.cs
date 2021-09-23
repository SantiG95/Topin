using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoyoController : MonoBehaviour
{
    ParticleSystem particulas;

    // Start is called before the first frame update
    void Start()
    {
        particulas = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducirParticulas()
    {
        particulas.Play();
    }

    public void pausarParticulas()
    {
        if (particulas.isPlaying)
        {
            particulas.Pause();
        }
    }

    public void despausarParticulas()
    {
        if (particulas.isPaused)
        {
            particulas.Play();
        }
    }
}
