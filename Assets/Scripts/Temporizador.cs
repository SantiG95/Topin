using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI temporizador;
    ControlDeTopos controlDeTopos;

    bool avanzarTiempo = true;
    public float tiempoRestante;
    // Start is called before the first frame update
    void Start()
    {
        tiempoRestante = GameObject.Find("Manager").GetComponent<GameManager>().darTiempoInicial() + 0.5f;
        controlDeTopos = GameObject.Find("Grupo de topos").GetComponent<ControlDeTopos>();

        avanzarTiempo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (avanzarTiempo)
        {
            tiempoRestante -= Time.deltaTime;
            escribirTiempo((int)tiempoRestante);
            if(tiempoRestante <= 0)
            {
                avanzarTiempo = false;
            }
        }
    }
    public void escribirTiempo(int tiempoRestante)
    {
        string tiempoString = tiempoRestante.ToString();
        string resultado = "";

        for (int i = 0; i < tiempoString.Length; i++)
        {
            resultado += "<sprite name=\"Numeros_" + tiempoString[i] + "\">";
        }
        
        temporizador.text = resultado;
    }

    public void empezarTiempo()
    {
        avanzarTiempo = true;
        controlDeTopos.despausarTopos();
        GameObject.Find("Manager").GetComponent<AudioSource>().Play();
    }

    public void detenerTiempo()
    {
        avanzarTiempo = false;
        controlDeTopos.pausarTopos();
        GameObject.Find("Manager").GetComponent<AudioSource>().Pause();
    }

    public float darTiempo()
    {
        return tiempoRestante;
    }

    public bool juegoAvanza()
    {
        return avanzarTiempo;
    }
    
    public void cambiarTiempo()
    {
        if (avanzarTiempo)
        {
            detenerTiempo();
        }
        else
        {
            empezarTiempo();
        }
    }

}
