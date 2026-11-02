using UnityEngine;

/// <summary>
/// Guarda dos posiciones/tamaños para un elemento de UI: una para horizontal y otra para vertical.
/// En Play elige la correcta según la orientación de la pantalla.
/// Uso: acomoda el elemento con la Game view en vertical, clic derecho en el componente >
/// "Guardar como VERTICAL". Luego cambia la Game view a horizontal, acomoda y "Guardar como HORIZONTAL".
/// </summary>
[RequireComponent(typeof(RectTransform))]
public class ResponsiveRect : MonoBehaviour
{
    [System.Serializable]
    public struct Layout
    {
        public bool saved;
        public Vector2 anchorMin, anchorMax, pivot, anchoredPosition, sizeDelta;
    }

    public Layout landscape;
    public Layout portrait;

    private RectTransform rt;
    private int lastState = -1;

    private void Awake() { rt = GetComponent<RectTransform>(); }
    private void OnEnable() { lastState = -1; Apply(); }
    private void Update() { Apply(); }

    private void Apply()
    {
        int state = Screen.height > Screen.width ? 1 : 0;
        if (state == lastState) return;
        lastState = state;
        if (rt == null) rt = GetComponent<RectTransform>();
        Layout l = state == 1 ? portrait : landscape;
        if (!l.saved) return;
        rt.anchorMin = l.anchorMin;
        rt.anchorMax = l.anchorMax;
        rt.pivot = l.pivot;
        rt.anchoredPosition = l.anchoredPosition;
        rt.sizeDelta = l.sizeDelta;
    }

    private Layout Capture()
    {
        var r = GetComponent<RectTransform>();
        return new Layout
        {
            saved = true,
            anchorMin = r.anchorMin,
            anchorMax = r.anchorMax,
            pivot = r.pivot,
            anchoredPosition = r.anchoredPosition,
            sizeDelta = r.sizeDelta
        };
    }

    [ContextMenu("Guardar como VERTICAL")]
    private void SavePortrait() { portrait = Capture(); }

    [ContextMenu("Guardar como HORIZONTAL")]
    private void SaveLandscape() { landscape = Capture(); }
}
