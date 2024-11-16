using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoEReset : MonoBehaviour
{
public ObjetivoEUpdater clipboard;
    public string ObjetivoE;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entr� en el Trigger"); // Muestra mensaje en la consola
        if (other.CompareTag("Player"))
        {
            Debug.Log("El objeto es el hacha"); // Confirma que el objeto es el jugador
            clipboard.UpdateObjetivoE(ObjetivoE);
        }
        else
        {
            Debug.Log("El objeto no es el hacha");
        }
    }
}
