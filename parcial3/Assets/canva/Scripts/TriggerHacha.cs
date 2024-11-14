using UnityEngine;

public class TriggerHacha : MonoBehaviour
{
    public ObjetivoEUpdater clipboard;
    public string ObjetivoE;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró en el Trigger"); // Muestra mensaje en la consola
        if (other.CompareTag("Hacha"))
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

