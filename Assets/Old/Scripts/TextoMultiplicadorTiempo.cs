using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoMultiplicadorTiempo : MonoBehaviour
{
    public float duraci�n;
    void Start()
    {
        Destroy(gameObject, duraci�n);
    }
}
