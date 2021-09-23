using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    public TextMeshProUGUI puntuacion;

    public int cantidadPuntuacion = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void escribirPuntuacion()
    {
        string puntosString = cantidadPuntuacion.ToString();
        string resultado = "";

        for(int i = 0; i<puntosString.Length; i++)
        {
            resultado += "<sprite name=\"n" + puntosString[i] + "\">";
        }

        puntuacion.text = resultado;
    }

    public void agregarPuntaje(int puntos)
    {
        cantidadPuntuacion += puntos;

        escribirPuntuacion();
    }

    public int darPuntuacion()
    {
        return cantidadPuntuacion;
    }
}
