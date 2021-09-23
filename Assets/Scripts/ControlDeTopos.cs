using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDeTopos : MonoBehaviour
{
    public List<TopoController> listaTopos;

    public int numeroToposDisponibles = 0;
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(prepararTopos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator prepararTopos()
    {
        foreach (Transform topo in transform)
        {
            listaTopos.Add(topo.GetChild(0).GetComponent<TopoController>());
            numeroToposDisponibles++;
        }
        yield return null;
    }

    public void generarTopo()
    {
        int index;
        if (toposDisponibles() > 0)
        {
            while (true)
            {
                index = Random.Range(0, listaTopos.Count);
                if (listaTopos[index].estaEnElHoyo())
                {
                    break;
                }
            }
            listaTopos[index].cambiarEstado();
        }
    }

    public List<TopoController> obtenerTodosLosTopos()
    {
        return listaTopos;
    }

    public int toposDisponibles()
    {
        return numeroToposDisponibles;
    }

    public void sumarTopo()
    {
        numeroToposDisponibles++;
    }

    public void restarTopo()
    {
        numeroToposDisponibles--;
    }

    public void pausarTopos()
    {
        for (int i = 0; i < listaTopos.Count; i++)
        {
            listaTopos[i].pausarTopo();
        }
    }

    public void despausarTopos()
    {
        for (int i = 0; i < listaTopos.Count; i++)
        {
            listaTopos[i].despausarTopo();
        }
    }

    public void toposIntocables()
    {
        foreach (TopoController topo in listaTopos)
        {
            topo.topoAlHoyo();
        }
    }
}
