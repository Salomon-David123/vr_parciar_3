using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float dummys;
    public Text cronometroText; // Referencia al texto en el Canvas
    public string sceneName; // Nombre de la escena a la que se cambiar�

    public float contadorTiempo = 0f; // Contador de tiempo
    private bool cronometroActivo = true; // Estado del cron�metro

    public static GameManager instancia; // Singleton

    void Awake()
    {
        // Asegura que solo haya un GameManager y no se destruya entre escenas
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // No destruye este objeto al cargar una nueva escena
        }
        else
        {
            Destroy(gameObject); // Destruye el duplicado si ya hay uno
        }
    }

    void Update()
    {
        if (cronometroActivo)
        {
            // Incrementa el tiempo
            contadorTiempo += Time.deltaTime;

            // Convierte el tiempo a minutos y segundos
            int minutos = Mathf.FloorToInt(contadorTiempo / 60);
            int segundos = Mathf.FloorToInt(contadorTiempo % 60);

            // Actualiza el texto del cron�metro con formato mm:ss
            cronometroText.text = string.Format("Tiempo: {0:00}:{1:00}", minutos, segundos);

            // Verifica si el tiempo alcanza el l�mite
            if (dummys > 6)
            {
                PausarCronometro();
                ChangeScene();
            }
        }
    }

    public void PausarCronometro()
    {
        cronometroActivo = false;
        Debug.Log("Cron�metro pausado");
    }

    public void ReiniciarCronometro()
    {
        contadorTiempo = 0f;
        cronometroActivo = true;
        Debug.Log("Cron�metro reiniciado");
    }

    public void sumarDummys()
    {
        dummys += 1;
        Debug.Log("Entro un dummy");
    }

    public void RestarDummys()
    {
        dummys -= 1;
        Debug.Log("Sali� un dummy");
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
            Debug.LogWarning("El nombre de la escena no est� asignado.");
        }
    }
}
