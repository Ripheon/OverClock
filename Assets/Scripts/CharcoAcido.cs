using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoAcido : MonoBehaviour
{
    public float tiempoDeDaņo;
    public GameObject player;
    public int daņoCharcoAcido;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DaņoCharco()
    {
        tiempoDeDaņo += 1 * Time.deltaTime;

        if (tiempoDeDaņo >= 2f)
        {
            player.GetComponent<ValorSalud>().CambioDeVida(daņoCharcoAcido);

            tiempoDeDaņo = 0;
            Destroy(gameObject, 2);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            DaņoCharco();
        }
    }
}
