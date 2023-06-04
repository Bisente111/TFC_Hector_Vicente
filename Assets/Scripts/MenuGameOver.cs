using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    public GameObject menuGameOver;

    private Jugador jugador;

    public void Start() {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        jugador.MuerteJugador += ActivarMenu;
    }

    public void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }




    public void Reiniciar(string nombre) {
        SceneManager.LoadScene(nombre);
        DestruccionEnemigo.enemiesDestroyed = 0;
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
