using UnityEngine;
using TMPro;

public class ObjetivoUpdater : MonoBehaviour
{
    public TextMeshProUGUI objetivoText; 

    public void UpdateObjetivo(string newObjetivo)
    {
        objetivoText.text = newObjetivo;
    }
}