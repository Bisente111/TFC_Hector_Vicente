using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoIA : MonoBehaviour
{
    public Transform objetivo;
    private bool perseguir;
    public float distancia;
    private float distanciaAbs;

    public float Speed;
    public float SpeedToTarget;
    private bool derecha;
	private float contador;
	public float tiempocambio = 4f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start()
	{
        animator = GetComponent<Animator>();
		contador = tiempocambio;
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
        distancia = Vector2.Distance(transform.position, objetivo.position);
        animator.SetFloat("Distancia", distancia);
        distanciaAbs = Mathf.Abs(distancia);
        if (Target()) {
            perseguir = true;
            if (perseguir)
            {
                transform.position = Vector2.MoveTowards(transform.position, objetivo.position, SpeedToTarget * Time.deltaTime);
            }

            if (distancia > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (distancia < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
		else
		{
            perseguir = false;
            if (derecha)
            {
                transform.position += Vector3.right * Speed * Time.deltaTime;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (!derecha)
            {
                transform.position += Vector3.left * Speed * Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
		contador -= Time.deltaTime;

		if (contador <= 0) {
			contador = tiempocambio;
			derecha = !derecha;
		}
	}



	bool Target()
	{
		bool target = false;
        if (distanciaAbs <= 7)
        {
            target = true;
        }
        return target;
	}
}
