using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoriaScript : MonoBehaviour
{
    public GameObject victoriaMen�, victoriaNoFinal, victoriaFinal;

    private void Start()
    {
        victoriaMen�.SetActive(false);
        victoriaFinal.SetActive(false);
        victoriaNoFinal.SetActive(false);
    }
}
