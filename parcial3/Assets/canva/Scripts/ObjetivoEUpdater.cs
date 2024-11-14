using UnityEngine;
using TMPro;

public class ObjetivoEUpdater : MonoBehaviour
{
    public TextMeshProUGUI ObjetivoEText;

    public void UpdateObjetivoE(string newObjetivoE)
    {
        ObjetivoEText.text = newObjetivoE;
    }
}
