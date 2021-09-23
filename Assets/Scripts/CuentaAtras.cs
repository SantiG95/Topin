using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    Transform tres;
    Transform dos;
    Transform uno;

    public GameObject manager;
    public GameObject botonPausa;

    // Start is called before the first frame update
    void Start()
    {
        tres = GameObject.Find("Tres").GetComponent<Transform>();
        dos = GameObject.Find("Dos").GetComponent<Transform>();
        uno = GameObject.Find("Uno").GetComponent<Transform>();

        empezarCuentaAtras();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void empezarCuentaAtras()
    {
        StartCoroutine(contandoAtras());
    }

    IEnumerator contandoAtras()
    {
        tres.position = new Vector2(-1.25f, -2);
        yield return new WaitForSeconds(1);
        tres.position = new Vector2(0, 10);
        dos.position = new Vector2(-1.8f, -3);
        yield return new WaitForSeconds(1);
        dos.position = new Vector2(0, 10);
        uno.position = new Vector2(-2.4f, -4);
        yield return new WaitForSeconds(1);
        uno.position = new Vector2(0, 10);

        GameObject.Find("UI").GetComponent<Temporizador>().empezarTiempo();
        manager.GetComponent<AudioSource>().Play();
        botonPausa.SetActive(true);
    }
}
