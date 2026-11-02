using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Cambia el sprite de un Image según el idioma (ES/EN). Úsalo en la imagen de controles.
/// </summary>
[RequireComponent(typeof(Image))]
public class LocalizedImage : MonoBehaviour
{
    [SerializeField] private Sprite spanish;
    [SerializeField] private Sprite english;

    private Image image;

    private void Awake() { image = GetComponent<Image>(); }

    private void OnEnable()
    {
        LanguageManager.OnLanguageChanged += Refresh;
        Refresh();
    }

    private void OnDisable() { LanguageManager.OnLanguageChanged -= Refresh; }

    private void Refresh()
    {
        if (image == null) image = GetComponent<Image>();
        image.sprite = LanguageManager.IsSpanish ? spanish : english;
    }
}
