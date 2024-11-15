using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que se cambiará
    public string sceneName2;
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
    public void ChangeScene2()
    {
        if (!string.IsNullOrEmpty(sceneName2))
        {
            SceneManager.LoadScene(sceneName2);
            Debug.Log("Cambiando a la escena: " + sceneName2);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no está asignado.");
        }
    }
}
