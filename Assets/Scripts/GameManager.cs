using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Puntuacion puntuacion;
    Temporizador temporizador;
    SonidosJuego sonidos;

    public ControlDeTopos grupoTopos;
    public GameObject resultados;
    public GameObject botonPausa;

    public float contador = 0;

    public float tiempoInicial = 60;
    public float tiempoSpawn = 3;
    public float tiempoMarca = 50;

    float marcaTiempo;

    bool juegoFinalizado = false;

    // Start is called before the first frame update
    void Start()
    {
        sonidos = GameObject.Find("Main Camera").GetComponent<SonidosJuego>();
        puntuacion = GameObject.Find("UI").GetComponent<Puntuacion>();
        temporizador = GameObject.Find("UI").GetComponent<Temporizador>();
        marcaTiempo = temporizador.darTiempo();

        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        //Tiempo generacion de topos
        if (marcaTiempo - temporizador.darTiempo() > tiempoSpawn)
        {
            marcaTiempo = temporizador.darTiempo();
            grupoTopos.generarTopo();

            if(temporizador.darTiempo() < tiempoMarca)
            {
                tiempoSpawn -= 0.5f;
                tiempoMarca -= 10;
            }
        }


        
        //Pausar juego
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (temporizador.juegoAvanza())
            {
                temporizador.detenerTiempo();
            }
            else
            {
                temporizador.empezarTiempo();
            }
        }

        //Finalizar Juego
        if (!juegoFinalizado && temporizador.darTiempo() < 0)
        {
            mostrarResultados();
        }
    }

    public float darTiempoInicial()
    {
        return tiempoInicial;
    }

    public void mostrarResultados()
    {
        botonPausa.SetActive(false);
        sonidos.reproducirSonidoFinDelJuego();
        Cursor.visible = true;
        juegoFinalizado = true;
        resultados.SetActive(true);
        resultados.GetComponent<Resultados>().copiarPuntaje();
        grupoTopos.toposIntocables();
        GameObject.Find("UI").SetActive(false);
        GameObject.Find("Martillo").SetActive(false);
    }
}
