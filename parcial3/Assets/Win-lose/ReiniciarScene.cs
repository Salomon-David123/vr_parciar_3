using System.Collections; // Para usar corutinas e interfaces como IEnumerator
using UnityEngine; // Para las clases base de Unity
using UnityEngine.SceneManagement; // Para cambiar de escena
using UnityEngine.XR; // Para trabajar con dispositivos XR y clases como InputDevices y XRNode
public class ReiniciarScene : MonoBehaviour
{
    public XRNode handType = XRNode.RightHand; // Selecciona la mano (izquierda o derecha)
    private InputDevice handDevice;

    private void Start()
    {
        // Obtiene el dispositivo VR de la mano especificada
        handDevice = InputDevices.GetDeviceAtXRNode(handType);
    }

    private void Update()
    {

        // Verifica si el dispositivo está disponible
        if (!handDevice.isValid)
        {
            handDevice = InputDevices.GetDeviceAtXRNode(handType);
        }

        StartCoroutine(reiniciar());
    }

    IEnumerator reiniciar()
    {
        yield return new WaitForSeconds(2f);
        // Revisa si el usuario hace el gesto de "agarre" o "pellizco"
        bool isGripping;
        if (handDevice.TryGetFeatureValue(CommonUsages.gripButton, out isGripping) && isGripping)
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        // Cargar la escena indicada
        SceneManager.LoadScene("TercerParcial");
    }
}
