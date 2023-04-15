using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class MovimientoJug : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    //Movimiento
    public Vector2 direccion;
    private static float velocidadMov = 10;
    private bool esDerecha = false;
    //Dash
    private static float velocidadDash = 20;
    public float tiempoDash;
    public TrailRenderer tr;
    private float gravedadInicial;
    private bool puedeHacerDash = true;
    private bool sePuedeMover = true;


    //Animacion
    private Animator animator;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gravedadInicial = rb2d.gravityScale;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        animator.SetFloat("Y", (direccion.y));
        animator.SetFloat("X", Mathf.Abs(direccion.x));
        if (direccion.y==0 && direccion.x==0) {
            animator.SetBool("Inactivo", true);
        }
        else
        {
            animator.SetBool("Inactivo", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && puedeHacerDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        sePuedeMover = false;
        puedeHacerDash = false;
        rb2d.gravityScale = 0;
        rb2d.velocity = new Vector2(velocidadDash * direccion.x, velocidadDash * direccion.y);
        tr.emitting = true;

        yield return new WaitForSeconds(tiempoDash);

        sePuedeMover = true;
        puedeHacerDash = true;
        tr.emitting = false;
        rb2d.gravityScale = gravedadInicial;
    }

    //Funciona igual que el update, pero se suele usar para todo lo relacionado con las fisicas
    //sirve para que pueda funcionar de la misma forma en equipos buenos, como en no tan buenos
    private void FixedUpdate()
    {
        if (sePuedeMover)
            Mover();

    }

    private void Mover()
    {
        rb2d.MovePosition(rb2d.position + direccion * velocidadMov * Time.fixedDeltaTime);
        if (direccion.x > 0 && !esDerecha)
        {
            Girar();
        } 
        else if (direccion.x < 0 && esDerecha)
        {
            Girar();
        }
    }

    private void Girar()
    {
        esDerecha = !esDerecha;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public static void isAtack(bool ataque)
    {
        Timer timer;
        if (ataque)
        {
            velocidadDash = 0;
            velocidadMov = 0;
        }
        timer = new Timer(1000);
        timer.Elapsed += (sender, e) =>
        {
            velocidadDash = 20;
            velocidadMov = 10;
        };
        timer.Start();
    }
}
