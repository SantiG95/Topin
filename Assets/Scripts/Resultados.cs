using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resultados : MonoBehaviour
{
    public GameObject puntaje;
    public GameObject puntajeResultado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void copiarPuntaje()
    {
        puntajeResultado.GetComponent<Puntuacion>().agregarPuntaje(puntaje.GetComponent<Puntuacion>().darPuntuacion());
    }
}
