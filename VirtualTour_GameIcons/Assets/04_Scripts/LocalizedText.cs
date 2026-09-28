using UnityEngine;
using TMPro;

// Colocar en cualquier texto TMP de la interfaz (botones, títulos, etc.)
// que deba cambiar de idioma. Escribe el texto en español e inglés en el Inspector.
[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [TextArea] public string spanish;
    [TextArea] public string english;

    private TMP_Text label;

    void Awake()
    {
        label = GetComponent<TMP_Text>();
    }

    void OnEnable()
    {
        LanguageManager.OnLanguageChanged += Refresh;
        Refresh();
    }

    void OnDisable()
    {
        LanguageManager.OnLanguageChanged -= Refresh;
    }

    void Refresh()
    {
        label.text = LanguageManager.IsSpanish ? spanish : english;
    }
}
