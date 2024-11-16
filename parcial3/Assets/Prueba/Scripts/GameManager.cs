using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float dummys;
    public Text cronometroText; // Referencia al texto en el Canvas
    public Text dummysText; // Referencia al texto que muestra los dummys
    public Text resultadoText; // Referencia al texto que muestra el mensaje de aprobación o reprobación
    public string sceneName; // Nombre de la escena a la que se cambiará
    public string sceneName2;

    public float contadorTiempo = 0f; // Contador de tiempo
    private bool cronometroActivo = true; // Estado del cronómetro

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

            // Actualiza el texto del cronómetro con formato mm:ss
            if (cronometroText != null)
                cronometroText.text = string.Format("Tiempo: {0:00}:{1:00}", minutos, segundos);

            // Actualiza el texto de dummys
            if (dummysText != null)
                dummysText.text = "Dummys: " + dummys;

            // Verifica si el tiempo alcanza el límite de 6 minutos
            if (minutos >= 6 && dummys > 5)
            {
                PausarCronometro();
                MostrarResultado(false);
                ChangeScene2();
            }
            else if (dummys > 5)
            {
                PausarCronometro();
                ChangeScene();
                MostrarResultado(true);
            }
        }
    }

    public void PausarCronometro()
    {
        cronometroActivo = false;
        Debug.Log("Cronómetro pausado");
    }

    public void ReiniciarCronometro()
    {
        contadorTiempo = 0f;
        cronometroActivo = true;
        Debug.Log("Cronómetro reiniciado");
    }

    public void sumarDummys()
    {
        dummys += 1;
        Debug.Log("Entro un dummy");
    }

    public void RestarDummys()
    {
        dummys -= 1;
        Debug.Log("Salió un dummy");
    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            StartCoroutine(SetupUIInNewScene());
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
            StartCoroutine(SetupUIInNewScene());
            Debug.Log("Cambiando a la escena: " + sceneName2);
        }
        else
        {
            Debug.LogWarning("El nombre de la escena no está asignado.");
        }
    }

    public void MostrarResultado(bool aprobado)
    {
        if (resultadoText != null)
        {
            if (aprobado)
            {
                resultadoText.text = "¡Aprobaste!";
                resultadoText.color = Color.green;
            }
            else
            {
                resultadoText.text = "Reprobaste. Te pasaste de 6 minutos.";
                resultadoText.color = Color.red;
            }

            resultadoText.gameObject.SetActive(true);
        }
    }

    private IEnumerator SetupUIInNewScene()
    {
        yield return null; // Espera un frame para asegurarte de que la escena haya cargado

        // Busca los textos en la nueva escena
        cronometroText = GameObject.Find("CronometroText")?.GetComponent<Text>();
        dummysText = GameObject.Find("DummysText")?.GetComponent<Text>();
        resultadoText = GameObject.Find("ResultadoText")?.GetComponent<Text>();

        // Actualiza los textos con los valores actuales
        if (cronometroText != null)
        {
            int minutos = Mathf.FloorToInt(contadorTiempo / 60);
            int segundos = Mathf.FloorToInt(contadorTiempo % 60);
            cronometroText.text = string.Format("Tiempo: {0:00}:{1:00}", minutos, segundos);
        }

        if (dummysText != null)
            dummysText.text = "Dummys: " + dummys;

        if (resultadoText != null)
            resultadoText.gameObject.SetActive(false); // Oculta el texto de resultado inicialmente
    }
}