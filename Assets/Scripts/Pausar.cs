using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject.Find("UI").GetComponent<Temporizador>().cambiarTiempo(); 
    }
}
