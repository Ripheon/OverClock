using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        Muerte();
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
            jugadorObj.GetComponent<MovimientoJugador>().enabled = false;
            jugadorObj.GetComponent<NavMeshAgent>().destination = new Vector3 (transform.position.x, jugadorObj.transform.position.y, transform.position.z + 2);
        }
    }

    void Muerte()
    {
        if(Input.GetKey(KeyCode.F))
        {
            jugadorObj.GetComponent<MovimientoJugador>().enabled = true;
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeteccion);
    }
}
