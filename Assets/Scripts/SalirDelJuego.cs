﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SalirDelJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(salir);
    }
    private void salir()
    {
        GameObject.Find("TituloManager").GetComponent<TituloManager>().salirDelJuego();
    }
}
