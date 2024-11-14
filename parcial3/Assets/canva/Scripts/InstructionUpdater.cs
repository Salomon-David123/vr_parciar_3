using UnityEngine;
using TMPro;

public class InstructionUpdater : MonoBehaviour
{
    public TextMeshProUGUI instructionText; 

    public void UpdateInstructions(string newInstructions)
    {
        instructionText.text = newInstructions;
    }
}
