using UnityEngine;

/// <summary>
/// Poner en la Main Camera de las escenas de personaje.
/// En vertical, el modelo se dibuja solo en la parte de arriba de la pantalla
/// (dejando abajo espacio para el panel de información) y se abre un poco el campo de visión
/// para que el personaje no se vea cortado.
/// </summary>
[RequireComponent(typeof(Camera))]
public class MobileCameraFit : MonoBehaviour
{
    [Header("Vertical (celular)")]
    public float portraitFov = 70f;
    [Tooltip("x, y, ancho, alto (0 a 1). y = 0.4 deja libre el 40% inferior para el panel.")]
    public Rect portraitViewport = new Rect(0f, 0.4f, 1f, 0.6f);

    private Camera cam;
    private float landscapeFov;
    private Rect landscapeViewport;
    private int lastState = -1;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        landscapeFov = cam.fieldOfView;
        landscapeViewport = cam.rect;
    }

    private void Update()
    {
        int state = Screen.height > Screen.width ? 1 : 0;
        if (state == lastState) return;
        lastState = state;
        cam.fieldOfView = state == 1 ? portraitFov : landscapeFov;
        cam.rect = state == 1 ? portraitViewport : landscapeViewport;
    }
}
