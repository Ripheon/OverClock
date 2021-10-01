using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public CharacterController controlador;

    public float velocidadMovimiento = 10f;
    public float gravedad = -15f;
    public float saltoAltura = 3f;

    public Transform controlSuelo;
    public float distanciaSuelo = 0.4f;
    public LayerMask sueloFiltro;

    public Vector3 velocidad;
    public bool enSuelo;

    public bool inmovilizado = false;

    void Start()
    {
        gameObject.transform.parent = null;

    }

    void Update()
    {
        Movimiento();

    }
    void Movimiento()
    {
        //Comprobar si est�s en el suelo
        enSuelo = Physics.CheckSphere(controlSuelo.position, distanciaSuelo, sueloFiltro);
        if (enSuelo && velocidad.y < 0)
        {
            velocidad.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movimiento = transform.right * x + transform.forward * z;
        if(!inmovilizado)
        {
            controlador.Move(movimiento * velocidadMovimiento * Time.deltaTime);

            if (Input.GetButton("Jump") && enSuelo)
            {
                velocidad.y = Mathf.Sqrt(saltoAltura * -2f * gravedad);
            }
        }
        
        velocidad.y += gravedad * Time.deltaTime;

        controlador.Move(velocidad * Time.deltaTime);
    }
}
