using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinEntrenamiento : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró en el Trigger"); // Muestra mensaje en la consola
        if (other.CompareTag("Dummy"))
        {
            Debug.Log("El objeto es el dummy"); // Confirma que el objeto es el jugador
            entrenamientoEnd();
        }
        else
        {
            Debug.Log("El objeto no es el dummy");
        }
    }

    private void entrenamientoEnd()
    {
        Debug.Log("fin del entrenamiento");
        SceneManager.LoadScene("TercerParcial");
    }
}

