using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Modelo : MonoBehaviour
{
    public enum Especie {Invitado, Cegador, Meloso, Escarabajo};
    public Especie Enemigos;
    public Animator animator;
    [HideInInspector]
    public RaycastHit hit;
    [HideInInspector]
    public GameObject objetivoJugador;

    //Patrulla
    public Detector deteccionPatrulla;
    public NavMeshAgent inteligencia;
    public GameObject[] puntoPatrulla;
    public GameObject patrullero;
    [HideInInspector]
    public float guardarVelocidad, guardarAceleracion;
    [HideInInspector]
    public bool candado = true, candadoDraw = false;
    [HideInInspector]
    public GameObject[] guardarPatrulla;
    [HideInInspector]
    public int fijador, patrullajePasado, numeroPatrulla, proximidad;
    [HideInInspector]
    public bool calmado = true;
    public EnemigoSentidos radar;

    //Vida
    public float vida;
    [HideInInspector]
    public float maxVida, guardarVida, valor, da�oVida;
    public float tiempoAnimacion;
    [HideInInspector]
    public bool liviana, pesada, enemigodSuicida, enemigoHumo, explosionAcido, explosionHumo, ataqueMelee, espera, estadoHorda, ataqueCaC;
    public GameObject charcoAcido, cortinaHumo, x2Letra, muerte,movimiento,recibirDa�o,golpe, inmuneSonido;
    public AudioClip[] sonidoMuerte;
    public AudioClip[] sonidoMovimiento;
    public AudioClip[] sonidoRecibirDa�o;
    public AudioClip[] sonidoAtaque;
    public AudioClip[] inmunidadSonar;
    [HideInInspector]
    public int contadorMuerte, detente, numerador, intentos, charcos, numeroSonido, escogerSonidoRecibirDa�o, escogerSonidoMuerte, escogerSonidoAtaque, escogerSonidoMovimiento;
    //Feedbacks
    public Material original;
    public GameObject modelado;
    public Material feedbackDa�o, feedbackImmune;
    [HideInInspector]
    public float tiempoFiltro = 0.2f, tiempo;
    [HideInInspector]
    public bool filtroTiro, filtroInmune;

    //Ataque
    public int da�o;
    public float frecuencia;
    public bool aturdidor;
    [HideInInspector]
    public float conteoAtaque, tiempoAtaque, tiempoAturdidor;
    public bool preparaAtaque, animacionAtaque;
    public Detector deteccionAtaque;
}
