using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTitulo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        GameObject.Find("TituloManager").GetComponent<TituloManager>().moverMartillo();
    }
}
