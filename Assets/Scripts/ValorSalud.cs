using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValorSalud : MonoBehaviour
{
    // En el HUD tiene que mostrar lo que es la variable vida (Si es jugador).
    public float vida;
    public bool jugador;
    [HideInInspector]
    public bool armadura;
    private GameObject objetivo;
    public GameObject charcoAcido, cortinaHumo,porDosObjecto;
    public bool enemigodSuicida, enemigoHumo;
    public ValorTiempoEnemigo regalo;
    public bool explosionAcido, explosionHumo, ataqueMelee;

    private int intentos, charcos;
    void Start()
    {
        intentos = 0;
        charcos = 0;
        if (jugador == false)
        {
            objetivo = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        Da�oExplosion();
    }
    public void CambioDeVida(float valor)
    {
        if (armadura==false|| valor > 0)
        {
            vida += valor;
        }
        VidaPersonaje();
        if (jugador == true && valor < 0)
        {
            GetComponent<FeedbackDa�o>().IniciaDa�o();
        }
        if (jugador == false)
        {
            GetComponent<FeedbackEnemigos>().Inicia();
        }
    }

    public void Da�oExplosion()
    {
        if (armadura == false)
        {
            if (explosionAcido == true)
            {
                vida -= 16;
                GetComponent<FeedbackDa�o>().IniciaDa�o();
            }
            if (explosionHumo == true)
            {
                vida -= 9;
                GetComponent<MovimientoJugador>().tiempoInmovilizado = 1.5f;
                GetComponent<MovimientoJugador>().inmovilizado = true;
                GetComponent<FeedbackDa�o>().IniciaDa�o();
            }
            explosionAcido = false;
            explosionHumo = false;
            VidaPersonaje();
        }

    }
    void VidaPersonaje()
    {
        if (vida <= 0)
        {
            if (jugador == false && intentos == 0)
            {
                intentos++;
                if (GetComponent<ValorTiempoEnemigo>().estadoHorda == false)
                {
                    objetivo.GetComponent<TiempoJugador>().ObtenerTiempo(regalo.valor);
                }
            }

            if (enemigodSuicida == true && charcos == 0)
            {
                charcos += 1;
                Vector3 Acido = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                Instantiate(charcoAcido, Acido, transform.rotation);
            }
            if (enemigoHumo == true && charcos == 0)
            {
                charcos += 1;
                Vector3 Humo = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                Instantiate(cortinaHumo, Humo, transform.rotation);
            }
            if(objetivo.GetComponent<TiempoJugador>().cambioFrenesi && GetComponent<ValorTiempoEnemigo>().estadoHorda == false)
            {
                Instantiate(porDosObjecto, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
    void Da�oArma()
    {
        vida -= 120;
        GetComponent<FeedbackEnemigos>().Inicia();
        VidaPersonaje();
    }

    void OnTriggerStay(Collider col)
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (jugador == true && other.gameObject.tag == "Explosion" && explosionAcido == false)
        {
            explosionAcido = true;
        }
        if (jugador == true && other.gameObject.tag == "Explosion2" && explosionHumo == false)
        {
            explosionHumo = true;
        }
        if (jugador == false && other.gameObject.tag == "ArmaAtaque")
        {
            Da�oArma();
        }
    }
}
