using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    public void CambiarVidaMaxima(float vidaMax) {
        slider.maxValue = vidaMax;
    }
    public void CambiarVidaActual(float cantidadVida)
    {
        slider.value = cantidadVida;
    }
    public void InicializarBarraDeVida(float cantidadVida)
    {
        slider = GetComponent<Slider>();
        CambiarVidaMaxima(cantidadVida);
        CambiarVidaActual(cantidadVida);
    }
}
