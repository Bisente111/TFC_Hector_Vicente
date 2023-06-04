using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;

    private bool juegoPausa = false;
    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (juegoPausa)
            {
                Reanudar();
            }
            else {
                Pausa();
            }
        }
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        menuPausa.SetActive(true);
        juegoPausa = true;
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        menuPausa.SetActive(false);
        juegoPausa = false;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Piso1", LoadSceneMode.Single);
        DestruccionEnemigo.enemiesDestroyed = 0;
    }

    public void Cerrar()
    {
        Application.Quit();
    }
}
