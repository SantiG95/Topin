using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martillo : MonoBehaviour
{
    [SerializeField] private Camera mainCamara;

    SpriteRenderer martilloSprite;

    public List<Sprite> listaMartillosSprites;
    private void Start()
    {
        martilloSprite = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(mainCamara.ScreenToWorldPoint(Input.mousePosition));
        Vector3 posicion = mainCamara.ScreenToWorldPoint(Input.mousePosition);

        posicion.z = 0;


        transform.position = posicion;

        if (Input.GetMouseButtonDown(0))
        {
            martilloSprite.sprite = listaMartillosSprites[1];
        }

        else if (Input.GetMouseButtonUp(0))
        {
            martilloSprite.sprite = listaMartillosSprites[0];
        }
    }

    
}
