using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoController : MonoBehaviour
{
    public Animator animador;
    public AudioClip puntajeSonido;

    SonidosJuego sonidos;
    Puntuacion puntaje;
    public HoyoController miHoyo;
    ControlDeTopos controlTopos;

    public int estado = 0;         // 0 oculto; 1 visible; 2 escapando
    bool tocable = false;

    public float contador = 0;
    public float contadorEscape = 0;

    public float tiempoEscape = 7;

    public int puntos = 10;
    bool tocablePrePausa;

    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
        controlTopos = GameObject.Find("Grupo de topos").GetComponent<ControlDeTopos>();
        puntaje = GameObject.Find("UI").GetComponent<Puntuacion>();
        sonidos = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tocable)
        {
            contador += Time.deltaTime;
        }

        if(contador > tiempoEscape)
        {
            cambiarEstado();
        }
    }

    public void cambiarEstado(bool fueGolpeado = false)
    {
        contador = 0;
        tocable = !tocable;
        if(estado == 0)
        {
            animador.SetTrigger("Salir");
            miHoyo.reproducirParticulas();
            estado = 1;
            controlTopos.restarTopo();
        }
        else if(fueGolpeado == true)
        {
            animador.SetTrigger("Golpear");
            estado = 0;
            controlTopos.sumarTopo();
            puntaje.agregarPuntaje(puntos);
            sonidos.reproducirSonidoTopo();
        }
        else
        {
            animador.SetTrigger("Escapar");
            estado = 0;
            controlTopos.sumarTopo();
        }
    }


    private void OnMouseDown()
    {
        if (tocable)
        {
            cambiarEstado(true);
        }
    }

    public bool estaEnElHoyo()
    {
        return (estado == 0);
    }

    public void pausarTopo()
    {
        animador.speed = 0;
        tocablePrePausa = tocable;
        tocable = false;
        miHoyo.pausarParticulas();
    }

    public void despausarTopo()
    {
        animador.speed = 1;
        tocable = tocablePrePausa;
        miHoyo.despausarParticulas();
    }

    public void topoAlHoyo()
    {
        if(estado == 1)
        {
            cambiarEstado();
        }
    }
}
