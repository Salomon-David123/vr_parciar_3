using System.Collections;
using UnityEngine;

public class TriggerCanvasActivator : MonoBehaviour
{
    public Canvas canvasToActivate; // Canvas que se activará
    public Camera mainCamera;       // Cámara principal que usará el canvas
    private bool hasActivated = false; // Verifica si ya se activó el canvas

    private void Start()
    {
        // Asegúrate de que el canvas esté desactivado al iniciar
        if (canvasToActivate != null)
        {
            canvasToActivate.enabled = false;

            // Configura el modo Screen Space - Camera si no está ya configurado
            if (canvasToActivate.renderMode != RenderMode.ScreenSpaceCamera && mainCamera != null)
            {
                canvasToActivate.renderMode = RenderMode.ScreenSpaceCamera;
                canvasToActivate.worldCamera = mainCamera;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("Player")) // Asegúrate de que es el jugador
        {
            hasActivated = true;
            StartCoroutine(ActivateCanvasForDuration(5f)); // Activa el canvas por 5 segundos
        }
    }

    private IEnumerator ActivateCanvasForDuration(float duration)
    {
        if (canvasToActivate != null)
        {
            canvasToActivate.enabled = true;
            yield return new WaitForSeconds(duration);
            canvasToActivate.enabled = false;
        }
    }
}
