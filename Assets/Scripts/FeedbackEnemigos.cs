using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackEnemigos : MonoBehaviour
{
    public Material original;
    public GameObject modelado;
    public Material feedbackDa�o;
    public float tiempoFiltro;
    private float tiempo;
    private bool filtrado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RecibirDa�o();
    }

    public void Inicia()
    {
        tiempo = 0;
        filtrado = true;
    }

    public void RecibirDa�o()
    {
        if (filtrado)
        {
            tiempo += Time.deltaTime;
            modelado.GetComponent<MeshRenderer>().material = feedbackDa�o;
            if (tiempo >= tiempoFiltro)
            {
                filtrado = false;
                modelado.GetComponent<MeshRenderer>().material = original;
            }
        }
        else
        {
            modelado.GetComponent<MeshRenderer>().material = original;
        }
    }
}
