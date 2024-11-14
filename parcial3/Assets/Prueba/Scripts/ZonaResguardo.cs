using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaResguardo : MonoBehaviour
{
    public GameManager manager;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el que debe activar la teletransportación
        if (other.CompareTag("Dummy")) // Cambia "Player" por el tag adecuado si es necesario
        {
          manager.sumarDummys();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sale del trigger tiene el tag "Player" (puedes cambiarlo al tag que desees)
        if (other.CompareTag("Dummy"))
        {
            manager.RestarDummys();
        }
    }
    

}
