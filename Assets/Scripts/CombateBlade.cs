using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateBlade : MonoBehaviour
{
    public Transform controladorAtaque;
    public float radioAtq;
    public static float radioAtaque;
    public float danioAtaque;

    private Enemigo enemigo;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        radioAtaque = radioAtq;
        if (Input.GetButtonDown("Fire1"))
        {
            Ataque();
        }
    }

    private void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        animator.SetTrigger("Ataque");
        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Enemigo"))
            {
                if (collision.gameObject.GetComponent<Enemigo>().Vida > 0)
                {
                    collision.transform.GetComponent<Enemigo>().RecibirDanio(danioAtaque);
                }
                
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
