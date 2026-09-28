using UnityEngine;
using UnityEngine.SceneManagement;

// Colocar en un GameObject vacío llamado "NavigationManager" en CADA escena.
// Conecta los botones del menú a estos métodos públicos desde el Inspector (OnClick).
public class SceneNavigationManager : MonoBehaviour
{
    [Header("Nombres EXACTOS de las escenas (deben coincidir con Build Settings)")]
    public string homeScene = "00_Home";
    public string kratosScene = "01_Kratos";
    public string masterChiefScene = "02_MasterChief";
    public string marcusFenixScene = "03_MarcusFenix";
    public string creditsScene = "04_Creditos";

    public void GoToHome() => LoadScene(homeScene);
    public void GoToKratos() => LoadScene(kratosScene);
    public void GoToMasterChief() => LoadScene(masterChiefScene);
    public void GoToMarcusFenix() => LoadScene(marcusFenixScene);
    public void GoToCredits() => LoadScene(creditsScene);

    // Botón ES / EN: cambia el idioma de toda la aplicación
    public void ToggleLanguage() => LanguageManager.Toggle();

    void LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("SceneNavigationManager: nombre de escena vacío.");
            return;
        }
        SceneManager.LoadScene(sceneName);
    }
}
