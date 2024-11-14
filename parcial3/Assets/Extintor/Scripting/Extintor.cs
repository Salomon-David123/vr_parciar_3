using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Extintor : MonoBehaviour
{
    public XRBaseInteractable grabInteract;
    public Disparar disparo;
    public GameObject shootFX;

    private bool isDisparando = false;

    void Start()
    {
        grabInteract.activated.AddListener(x => IniciarDisparo());
        grabInteract.deactivated.AddListener(x => DetenerDisparo());
    }

    public void IniciarDisparo()
    {
        if (!isDisparando)
        {
            isDisparando = true;
            disparo.IniciarDisparoContinuo(); 
        }
    }

    public void DetenerDisparo()
    {
        if (isDisparando)
        {
            isDisparando = false;
            disparo.DetenerDisparoContinuo(); 
        }
    }
}
