using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopoTitulo : MonoBehaviour
{
    Animator animador;
    bool avisar = true;
    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>();
    }

    void Update()
    {
        if(avisar && animador.GetCurrentAnimatorStateInfo(0).IsName("TopoTitulo-espera"))
        {
            avisar = false;
            GameObject.Find("TituloManager").GetComponent<TituloManager>().moverLogo();
        }
    }

    public void iniciarTopo()
    {
        animador.SetTrigger("Iniciar");
        GameObject.Find("TituloManager").GetComponent<TituloManager>().cargarJuego();

    }

    public void terminarTopo()
    {
        animador.SetTrigger("Terminar");
    }
}
