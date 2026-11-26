using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ResponsiveRect : MonoBehaviour
{
    [System.Serializable]
    public struct Layout
    {
        public bool saved;
        public Vector2 anchorMin, anchorMax, pivot, anchoredPosition, sizeDelta;
        public Vector3 scale;   // si es (0,0,0) se trata como (1,1,1): compatible con lo ya guardado
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
        rt.localScale = l.scale == Vector3.zero ? Vector3.one : l.scale;
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
            sizeDelta = r.sizeDelta,
            scale = r.localScale
        };
    }

    [ContextMenu("Guardar como VERTICAL")]
    private void SavePortrait() { portrait = Capture(); }

    [ContextMenu("Guardar como HORIZONTAL")]
    private void SaveLandscape() { landscape = Capture(); }
}