using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard : MonoBehaviour
{
    public MovimientoJugador jugadorM;
    public GameObject jugadorObj;

    public float rangoDeteccion;
    public bool enRangoVis�on;

    void Start()
    {
        jugadorM = GameObject.FindGameObjectWithTag("Player").GetComponent<MovimientoJugador>();
        jugadorObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vision();
        Atracci�n();
    }

    void Vision()
    {
        float dist = Vector3.Distance(jugadorObj.transform.position, transform.position);
        if (dist < rangoDeteccion)
        {
            enRangoVis�on = true;
        }
        else
        {
            enRangoVis�on = false;
        }
    }

    void Atracci�n()
    {
        if(enRangoVis�on)
        {
            jugadorM.inmovilizado = true;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
