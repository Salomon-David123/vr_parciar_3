/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    public int maxHealth = 300; 
    private int currentHealth;
    private ParticleSystem fuegoParticleSystem;

    void Start()
    {
        currentHealth = maxHealth;

        fuegoParticleSystem = GetComponent<ParticleSystem>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        
        UpdateOpacity();

        if (currentHealth <= 0)
        {
            Destroy(gameObject); 
        }
    }

    private void UpdateOpacity()
    {
        if (fuegoParticleSystem != null)
        {
            Debug.Log("reduciendo opacidad");
            float nuevaOpacidad = Mathf.Clamp01((float)currentHealth / maxHealth);

            // Configura el nuevo color con opacidad ajustada
            var mainModule = fuegoParticleSystem.main;
            Color colorActual = mainModule.startColor.color;
            colorActual.a = nuevaOpacidad;
            mainModule.startColor = colorActual;

            //ponerr particulas negras
        }
    }
} */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{
    public int maxHealth = 300; 
    private int currentHealth;
    private ParticleSystem fuegoParticleSystem;
    public ObjetivoEUpdater objetivoEUpdater; // Referencia al actualizador de Objetivo E
    public string textoNuevoObjetivoE = "Objetivo alcanzado"; // Texto a mostrar cuando la vida llegue a cero

    void Start()
    {
        currentHealth = maxHealth;

        fuegoParticleSystem = GetComponent<ParticleSystem>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        UpdateOpacity();

        if (currentHealth <= 0)
        {
            // Actualiza el texto del objetivo
            if (objetivoEUpdater != null)
            {
                objetivoEUpdater.UpdateObjetivoE(textoNuevoObjetivoE);
            }

            Destroy(gameObject); 
        }
    }

    private void UpdateOpacity()
    {
        if (fuegoParticleSystem != null)
        {
            Debug.Log("Reducción de opacidad en progreso");
            float nuevaOpacidad = Mathf.Clamp01((float)currentHealth / maxHealth);

            // Configura el nuevo color con opacidad ajustada
            var mainModule = fuegoParticleSystem.main;
            Color colorActual = mainModule.startColor.color;
            colorActual.a = nuevaOpacidad;
            mainModule.startColor = colorActual;
        }
    }
}
