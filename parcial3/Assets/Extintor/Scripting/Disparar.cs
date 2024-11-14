using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Disparar : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 5;
    public LineRenderer lineRenderer;
    public GameObject shootFX, impact;
    public AudioClip shootSound;
    private AudioSource audioSource;
    private bool isShooting = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; 
    }

    IEnumerator DisparoContinuo()
    {
        if (!audioSource.isPlaying) 
        {
            audioSource.clip = shootSound;
            audioSource.Play();
        }

        lineRenderer.enabled = true;

        while (isShooting)
        {
            RaycastHit hit;
            bool hitInfo = Physics.Raycast(firePoint.position, firePoint.forward, out hit, 5f);

            if (hitInfo)
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hit.point);

                GameObject impactInstance = Instantiate(impact, hit.point, Quaternion.identity);
                Destroy(impactInstance, 0.5f);

                Fuego fuego = hit.collider.GetComponent<Fuego>();
                if (fuego != null)
                {
                    fuego.TakeDamage(damage);
                }
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * 20);
            }

            GameObject shootFXInstance = Instantiate(shootFX, firePoint.position, firePoint.rotation);
            Destroy(shootFXInstance, 0.5f);

            yield return new WaitForSeconds(0.1f);
        }

        lineRenderer.enabled = false;
        audioSource.Stop(); 
    }

    public void IniciarDisparoContinuo()
    {
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(DisparoContinuo());
        }
    }

    public void DetenerDisparoContinuo()
    {
        isShooting = false;
        lineRenderer.enabled = false;
    }
}