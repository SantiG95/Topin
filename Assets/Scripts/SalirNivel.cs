using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SalirNivel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(cargarTitulo);
    }
    private void cargarTitulo()
    {
        SceneManager.LoadScene("Titulo");
    }
}
