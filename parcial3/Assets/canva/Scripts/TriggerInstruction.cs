using UnityEngine;

public class TriggerInstruction : MonoBehaviour
{
    public InstructionUpdater clipboard;
    public string instructions;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entró en el Trigger"); // Muestra mensaje en la consola
        if (other.CompareTag("Player"))
        {
            Debug.Log("El objeto es el jugador"); // Confirma que el objeto es el jugador
            clipboard.UpdateInstructions(instructions);
        }
        else
        {
            Debug.Log("El objeto no es el jugador");
        }
    }
}

