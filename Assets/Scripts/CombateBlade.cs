using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateBlade : MonoBehaviour
{
    public Transform controladorAtaque;
    public float radioAtaque;
    public float danioAtaque;

    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ataque();
        }
    }

    private void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        animator.SetTrigger("Ataque");
        MovimientoJug.isAtack(true);
        foreach (Collider2D collision in objetos)
        {
            if (collision.CompareTag("Enemigo"))
            {
                collision.transform.GetComponent<Enemigo>().tomarDanio(danioAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }
}
