using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Extintor : MonoBehaviour
{
    public XRBaseInteractable grabInteract;
    public Disparar disparo; // Aseg�rate de que es la versi�n de disparo continuo
    public GameObject shootFX;

    private bool isDisparando = false;

    void Start()
    {
        // Configura los eventos de activaci�n y desactivaci�n para el disparo
        grabInteract.activated.AddListener(x => IniciarDisparo());
        grabInteract.deactivated.AddListener(x => DetenerDisparo());
    }

    public void IniciarDisparo()
    {
        if (!isDisparando)
        {
            isDisparando = true;
            disparo.IniciarDisparoContinuo(); // Inicia el disparo continuo en el script de disparo
        }
    }

    public void DetenerDisparo()
    {
        if (isDisparando)
        {
            isDisparando = false;
            disparo.DetenerDisparoContinuo(); // Detiene el disparo continuo en el script de disparo
        }
    }
}
