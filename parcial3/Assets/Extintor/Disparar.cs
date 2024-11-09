using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Disparar : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 25;
    public LineRenderer lineRenderer;
    public GameObject shootFX, impact;
    public AudioClip shootSound;
    private AudioSource audioSource;
    private bool isShooting = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator DisparoContinuo()
    {
        // Activa el sonido y el rayo mientras el disparo esté activo
        audioSource.PlayOneShot(shootSound);
        lineRenderer.enabled = true;

        while (isShooting)
        {
            RaycastHit hit;
            bool hitInfo = Physics.Raycast(firePoint.position, firePoint.forward, out hit, 5f);

            if (hitInfo)
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hit.point);

                // Instancia y destruye el impacto después de 0.5 segundos
                GameObject impactInstance = Instantiate(impact, hit.point, Quaternion.identity);
                Destroy(impactInstance, 0.5f);
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * 20);
            }

            // Instancia y destruye el efecto de disparo en la punta del extintor
            GameObject shootFXInstance = Instantiate(shootFX, firePoint.position, firePoint.rotation);
            Destroy(shootFXInstance, 0.5f);

            yield return new WaitForSeconds(0.1f); // Controla la frecuencia del disparo
        }

        lineRenderer.enabled = false; // Desactiva el rayo cuando deja de disparar
    }

    // Método para iniciar el disparo continuo
    public void IniciarDisparoContinuo()
    {
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(DisparoContinuo());
        }
    }

    // Método para detener el disparo continuo
    public void DetenerDisparoContinuo()
    {
        isShooting = false;
        lineRenderer.enabled = false; // Asegura que el rayo se apague
    }
}
