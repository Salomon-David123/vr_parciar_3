using UnityEngine;

public class TriggerObjetivo : MonoBehaviour
{
    public ObjetivoUpdater clipboard;
    public string objetivo;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró en el Trigger"); // Muestra mensaje en la consola
        if (other.CompareTag("Player"))
        {
            Debug.Log("El objeto es el jugador"); // Confirma que el objeto es el jugador
            clipboard.UpdateObjetivo(objetivo);
        }
        else
        {
            Debug.Log("El objeto no es el jugador");
        }
    }
}
