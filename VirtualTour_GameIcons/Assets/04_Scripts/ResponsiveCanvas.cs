using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Poner en el Canvas (junto al Canvas Scaler).
/// Usa 1920x1080 en horizontal y 1080x1920 en vertical, para que los textos y botones
/// no se vean diminutos en el celular.
/// </summary>
[ExecuteAlways]
[RequireComponent(typeof(CanvasScaler))]
public class ResponsiveCanvas : MonoBehaviour
{
    public Vector2 landscapeReference = new Vector2(1920f, 1080f);
    public Vector2 portraitReference = new Vector2(1080f, 1920f);
    [Range(0f, 1f)] public float match = 0.5f;

    public static bool IsPortrait => Screen.height > Screen.width;

    private CanvasScaler scaler;
    private int lastW, lastH;

    private void OnEnable()
    {
        scaler = GetComponent<CanvasScaler>();
        lastW = lastH = -1;
        Apply();
    }

    private void Update()
    {
        if (scaler == null) scaler = GetComponent<CanvasScaler>();
        if (Screen.width != lastW || Screen.height != lastH) Apply();
    }

    private void Apply()
    {
        lastW = Screen.width;
        lastH = Screen.height;
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.referenceResolution = IsPortrait ? portraitReference : landscapeReference;
        scaler.matchWidthOrHeight = match;
    }
}
