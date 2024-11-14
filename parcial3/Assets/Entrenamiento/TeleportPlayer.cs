using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TeleportPlayer : MonoBehaviour
{
    public Transform player1; // Referencia al primer jugador
    public Transform player2; // Referencia al segundo jugador
    public Transform teleportLocation; // Referencia al lugar al que se teletransportarán
    

    void Start()
    {
       
    }

    public void Teleport()
    {
        if (player1 != null && player2 != null && teleportLocation != null)
        {
            player1.position = teleportLocation.position;
            player2.position = teleportLocation.position;
            Debug.Log("Jugadores teletransportados a: " + teleportLocation.position);
        }
        else
        {
            Debug.LogWarning("No se ha asignado uno de los jugadores o la ubicación de teletransporte.");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger es el que debe activar la teletransportación
        if (other.CompareTag("Player")) // Cambia "Player" por el tag adecuado si es necesario
        {
            Teleport();
        }

    }
}
