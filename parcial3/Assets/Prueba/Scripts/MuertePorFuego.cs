using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MuertePorFuego : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que se cambiará

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en el trigger tiene el tag "Player" (puedes cambiarlo al tag que desees)
        if (other.CompareTag("Player"))
        {
            Debug.Log("entro");
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log("Cambiando a la escena: " + sceneName);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no está asignado.");
        }
    }
    
}
