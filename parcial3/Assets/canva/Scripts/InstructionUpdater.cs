using UnityEngine;
using TMPro;

public class InstructionUpdater : MonoBehaviour
{
    public TextMeshProUGUI instructionText; // Vincula aquí el componente TextMeshProUGUI

    public void UpdateInstructions(string newInstructions)
    {
        instructionText.text = newInstructions;
    }
}
