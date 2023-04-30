using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad = 5f;
    public int Vida = 100;
    public float tiempoPatrullaje = 3f;
    public float distanciaTarget = 5f;

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
        }
    }

    // Metodo que se encarga de que el enemigo este patrullando
    void Patrullar()
    {
        tiempoPatrullar -= Time.deltaTime;

        if (tiempoPatrullar <= 0)
        {

            direccion = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized;
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
    public void RecibirDanio(int damage)
    {
        Vida -= damage;

        if (Vida <= 0)
        {
            Muerte();
        }
    }

    // Metodo de muerte
    void Muerte()
    {
        Destroy(gameObject);
    }
}
