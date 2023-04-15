using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoIATarget : MonoBehaviour
{
	public Transform objetivo;
	public float speed;
	public bool perseguir;
	public float distancia;
	public float distanciaAbs;
	public bool derecha;
	// Use this for initialization
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		distancia = objetivo.position.x - transform.position.x;
		distanciaAbs = Mathf.Abs(distancia);

		if (perseguir) {
			transform.position = Vector2.MoveTowards(transform.position, objetivo.position, speed*Time.deltaTime);
		}

		if (distancia>0) {
			transform.localScale = new Vector3(1, 1, 1);
		}
		if (distancia < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if (distanciaAbs <7)
		{
			perseguir = true;
		}
		else {
			perseguir = false;
		}
	}
}
