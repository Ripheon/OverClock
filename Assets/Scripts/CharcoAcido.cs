using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    public float tiempoDeDa�o;
    public GameObject player;
    public int da�oCharcoAcido;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Da�oCharco()
    {
        tiempoDeDa�o += 1 * Time.deltaTime;

        if (tiempoDeDa�o >= 2f)
        {
            player.GetComponent<ValorSalud>().CambioDeVida(da�oCharcoAcido);

            tiempoDeDa�o = 0;
            Destroy(gameObject, 2);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Da�oCharco();
        }
    }
}
