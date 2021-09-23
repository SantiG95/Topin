using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TituloManager : MonoBehaviour
{
    TopoTitulo topoTitulo;
    RectTransform logoPosicion;
    
    public GameObject logo;
    public GameObject botonTitulo;
    public GameObject martillo;
    public GameObject botonSalir;

    bool moverLogoBool = false;
    bool moverMartilloBool = false;
    


    // Start is called before the first frame update
    void Start()
    {
        topoTitulo = GameObject.Find("TopoTitulo").GetComponent<TopoTitulo>();
        logoPosicion = logo.GetComponent<RectTransform>();

        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moverLogoBool)
        {
            logoPosicion.anchoredPosition = new Vector2(logoPosicion.anchoredPosition.x, logoPosicion.anchoredPosition.y - Time.deltaTime * 100);
            
            if (logoPosicion.anchoredPosition.y < -140)
            {
                moverLogoBool = false;
                botonTitulo.SetActive(true);
                botonSalir.SetActive(true);
            }
        }

        if (moverMartilloBool)
        {
            martillo.transform.position = new Vector2(martillo.transform.position.x - Time.deltaTime * 7, martillo.transform.position.y);

            if (martillo.transform.position.x < 6)
            {
                moverMartilloBool = false;
                topoTitulo.iniciarTopo();
            }
        }

        
    }

    public void moverLogo()
    {
        moverLogoBool = true;
    }

    public void moverMartillo()
    {
        logo.SetActive(false);
        botonTitulo.SetActive(false);
        botonSalir.SetActive(false);
        moverMartilloBool = true;
    }

    public void cargarJuego()
    {
        StartCoroutine(cargarJuegoRoutine());
    }

    IEnumerator cargarJuegoRoutine()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Juego");
    }

    public void salirDelJuego()
    {
        logo.SetActive(false);
        botonTitulo.SetActive(false);
        botonSalir.SetActive(false);
        topoTitulo.terminarTopo();
        StartCoroutine(salirDelJuegoRoutine());
    }

    IEnumerator salirDelJuegoRoutine()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
        Debug.Log("Saliendo del juego");
    }

}
