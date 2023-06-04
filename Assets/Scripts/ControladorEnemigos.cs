using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;



public class ControladorEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    public Transform[] puntos;
    public GameObject[] enemigos;
    public float tiempoEnemigos;
    public float tiempoSiguienteEnemigo;
    public float contador = 0f;

    // Start is called before the first frame update
    public void Start()
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    public void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if (tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            if (contador < 10)
                crearEnemigos();
        }
        comprobarMuertes();
    }
    
    public void crearEnemigos()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
        contador += 1;
        

    }

    public void comprobarMuertes()
    {
        if (DestruccionEnemigo.enemiesDestroyed >= 20)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}






