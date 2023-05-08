using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void pantallaCompleta(bool pantallaCompleta) {
        Screen.fullScreen = pantallaCompleta;
    }

    public void cambiarVolumen(float volumen) {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void cambiarCalidad(int index) {
        QualitySettings.SetQualityLevel(index);
    }
}
