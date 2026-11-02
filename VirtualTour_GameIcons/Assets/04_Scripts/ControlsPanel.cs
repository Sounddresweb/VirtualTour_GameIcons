using UnityEngine;

/// <summary>
/// Pantalla inicial de controles (A-07) para la escena 00_Home.
/// - Muestra el panel de controles al abrir la aplicación.
/// - El botón "Iniciar recorrido" lo oculta y deja ver el menú de personajes.
/// - Un botón opcional "?" / "Controles" permite volver a abrirlo.
/// Se muestra solo la primera vez por sesión (al volver a Home desde otro personaje no molesta).
/// </summary>
public class ControlsPanel : MonoBehaviour
{
    [Tooltip("Panel con el texto de los controles y el botón Iniciar.")]
    [SerializeField] private GameObject controlsPanel;

    [Tooltip("Menú principal de Home (botones de personajes). Se oculta mientras el panel de controles está abierto. Opcional.")]
    [SerializeField] private GameObject mainMenu;

    [Tooltip("Si está activo, el panel se abre solo la primera vez. Si no, solo se abre con el botón Controles.")]
    [SerializeField] private bool showOnFirstLoad = false;

    private static bool alreadyShown;

    private void Start()
    {
        if (showOnFirstLoad && !alreadyShown) Show();
        else Hide();
    }

    public void Show()
    {
        if (controlsPanel != null) controlsPanel.SetActive(true);
        if (mainMenu != null) mainMenu.SetActive(false);
    }

    // Conectar al OnClick del botón "Iniciar recorrido".
    public void Hide()
    {
        alreadyShown = true;
        if (controlsPanel != null) controlsPanel.SetActive(false);
        if (mainMenu != null) mainMenu.SetActive(true);
    }
}
