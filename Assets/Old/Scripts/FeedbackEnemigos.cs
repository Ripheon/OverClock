using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackEnemigos : MonoBehaviour
{
    public Material original;
    public GameObject modelado;
    public Material feedbackDa�o, feedbackImmune;
    public float tiempoFiltro;
    private float tiempo;
    private bool filtroTiro, filtroInmune;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Feedbacks();
    }

    public void Inicia()
    {
        tiempo = 0;
        filtroTiro = true;

        if (animator != null)
        {
            animator.SetTrigger("Da�ado");
        }
    }
    public void InmunidadEmpiezo()
    {
        tiempo = 0;
        filtroInmune = true;
    }

    public void Feedbacks()
    {
        if (filtroTiro)
        {
            tiempo += Time.deltaTime;
            modelado.GetComponent<SkinnedMeshRenderer>().material = feedbackDa�o;
            if (tiempo >= tiempoFiltro)
            {
                filtroTiro = false;
                modelado.GetComponent<SkinnedMeshRenderer>().material = original;
            }
        }
        else if(filtroInmune)
        {
            tiempo += Time.deltaTime;
            modelado.GetComponent<SkinnedMeshRenderer>().material = feedbackImmune;
            if (tiempo >= tiempoFiltro)
            {
                filtroTiro = false;
                modelado.GetComponent<SkinnedMeshRenderer>().material = original;
            }
        }
        else
        {
            modelado.GetComponent<SkinnedMeshRenderer>().material = original;
        }

    }
}
