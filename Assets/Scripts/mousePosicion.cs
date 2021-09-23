using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePosicion : MonoBehaviour
{
    [SerializeField] private Camera mainCamara;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mainCamara.ScreenToWorldPoint(Input.mousePosition));
        Vector3 posicion = mainCamara.ScreenToWorldPoint(Input.mousePosition);

        posicion.z = 0;


        transform.position = posicion;
    }
}
