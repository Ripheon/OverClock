using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValorSalud : MonoBehaviour
{
    // En el HUD tiene que mostrar lo que es la variable vida (Si es jugador).
    public float vida;
    private float maxVida;
    public float tiempoAnimacion;
    private int detente, numerador;
    public float da�oVida;

    public bool jugador;
    [HideInInspector]
    public bool armadura, muerto;
    public bool liviana, pesada;
    private GameObject objetivo, objetoMuerte;
    public GameObject charcoAcido, cortinaHumo, porDosObjecto, sonidoMuerte, sonidoRecibirDa�o, sonidoRecibirDa�o2;
    public bool enemigodSuicida, enemigoHumo;
    public ValorTiempoEnemigo regalo;
    public bool explosionAcido, explosionHumo, ataqueMelee, espera;
    public AudioClip[] sonido;
    public AudioSource inmuneSonido;
    public AudioClip[] inmunidadSonar;

    private int intentos, charcos, numeroSonido, escogerSonidoRecibirDa�o;

    void Start()
    {
        muerto = false;
        da�oVida = vida;
        if (sonido.Length != 0)
        {
            numeroSonido = Random.Range(0, sonido.Length);
        }
        sonidoMuerte.transform.position = transform.position;
        sonidoMuerte.tag = "Sonidos";
        objetoMuerte=Instantiate(sonidoMuerte);

        intentos = 0;
        charcos = 0;
        if (jugador == false)
        {
            objetivo = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            maxVida=vida;
        }
    }

    void Update()
    {
        Da�oExplosion();

        RecibirDa�o();
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
        objetoMuerte.transform.position = transform.position;

    }

    public void RecibirDa�o()
    {
        if (jugador == false)
        {
            if (vida < da�oVida)
            {
                espera = true;
            }
            else
            {
                espera = false;
            }

            if(espera)
            {
                if (detente == 0)
                {
                    escogerSonidoRecibirDa�o = Random.Range(1, 3);
                    detente++;

                     Debug.Log("escoger");
                    switch (escogerSonidoRecibirDa�o)
                    {
                       case 1:
                          sonidoRecibirDa�o.SetActive(true);
                          break;
                       case 2:
                           sonidoRecibirDa�o2.SetActive(true);
                           break;
                    }
                }
                tiempoAnimacion += Time.deltaTime;
                if (tiempoAnimacion >= 0.5f)
                {
                    da�oVida = vida;
                }
            }
            else
            {
                Debug.Log("we");
                switch (escogerSonidoRecibirDa�o)
                {
                    case 1:
                        sonidoRecibirDa�o.SetActive(false);
                        break;
                    case 2:
                        sonidoRecibirDa�o2.SetActive(false);
                        break;
                }
                tiempoAnimacion = 0;
                detente = 0;
            }
        }
    }
    void VidaPersonaje()
    {
        if (vida <= 0 && muerto == false)
        {
            if (sonido.Length != 0)
            {
                objetoMuerte.GetComponent<AudioSource>().PlayOneShot(sonido[numeroSonido]);
            }
            if (jugador == false && intentos == 0)
            {
                intentos++;
                if (GetComponent<ValorTiempoEnemigo>().estadoHorda == false)
                {
                    objetivo.GetComponent<TiempoJugador>().ObtenerTiempo(regalo.valor);
                }
            }
            if (jugador == false)
            {
                if (objetivo.GetComponent<TiempoJugador>().cambioFrenesi && GetComponent<ValorTiempoEnemigo>().estadoHorda == false)
                {
                    Instantiate(porDosObjecto, transform.position, transform.rotation);
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
            muerto = true;
            Destroy(gameObject);
        }
        else if((vida>maxVida)&&jugador)
        {
            vida=maxVida;
        }
    }
    void Da�oArma()
    {
        vida -= 120;
        GetComponent<FeedbackEnemigos>().Inicia();
        VidaPersonaje();
    }

    public void Inmunencia()
    {
        if (inmunidadSonar.Length != 0)
        {
            GetComponent<FeedbackEnemigos>().InmunidadEmpiezo();
            numerador = Random.Range(0, inmunidadSonar.Length);
            inmuneSonido.clip = inmunidadSonar[numerador];
            inmuneSonido.Play(0);
        }
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
        if (jugador == false && other.gameObject.tag == "ArmaAtaque" && pesada == false)
        {
            Da�oArma();
        }
        else if (jugador == false && other.gameObject.tag == "ArmaAtaque" && pesada == true)
        {
            Inmunencia();
        }
    }
}
