using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosJuego : MonoBehaviour
{
    private AudioSource sonidosJuego;

    public AudioClip topoSonido;

    public AudioClip juegoTerminado;

    // Start is called before the first frame update
    void Start()
    {
        sonidosJuego = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducirSonidoTopo()
    {
        sonidosJuego.PlayOneShot(topoSonido, 1);
    }

    public void reproducirSonidoFinDelJuego()
    {
        sonidosJuego.PlayOneShot(juegoTerminado, 1);
    }
}
