using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 10f;
    public int Vida = 100;
    public float tiempoPatrullaje = 2f;
    public float distanciaTarget = 10f;
    public float rangoAtaque = 1f;
    public float danio = 10;

    private Transform player;
    private Vector2 direccion;
    private float tiempoPatrullar;
    private bool esPatrullando = true;

    private Animator animator;

    // Inicialización
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        tiempoPatrullar = tiempoPatrullaje;
    }

    // Actualización
    void Update()
    {
        if (esPatrullando)
        {
            Patrullar();
        }
        else
        {
            Perseguir();
            Attack();
        }
    }

    // Metodo que se encarga de que el enemigo este patrullando
    void Patrullar()
    {
        tiempoPatrullar -= Time.deltaTime;

        if (tiempoPatrullar <= 0f)
        {

            direccion = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            tiempoPatrullar = tiempoPatrullaje;
        }


        transform.position += (Vector3)direccion * velocidad * Time.deltaTime;


        if (Vector2.Distance(transform.position, player.position) <= distanciaTarget)
        {
            esPatrullando = false;
        }
    }

    // Metodo que se encarga de que persiga al jugador
    void Perseguir()
    {

        direccion = ((Vector2)player.position - (Vector2)transform.position).normalized;


        transform.position += (Vector3)direccion * velocidad * Time.deltaTime;


        if (Vector2.Distance(transform.position, player.position) > distanciaTarget * 1.5f)
        {
            esPatrullando = true;
        }
    }

    // Metodo para restar vida al enemio si es golpeado
    public void RecibirDanio(float damage)
    {
        Vida -= (int)damage;
        if (Vida <= 0)
        {
            Muerte();
        }
    }

    void Attack()
    {
        // Comprueba si el jugador está dentro del rango de ataque
        if (Vector2.Distance(transform.position, player.position) <= rangoAtaque)
        {
            // Reduce la salud del jugador
            Jugador vidaJugador = player.GetComponent<Jugador>();
            if (vidaJugador != null)
            {
                vidaJugador.RecibirDanio(danio);
            }
        }
    }

    // Dibuja un gizmo para mostrar la distancia de persecución y de ataque
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaTarget);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }

// Metodo de muerte
    void Muerte()
    {
        Destroy(gameObject);
    }
}
