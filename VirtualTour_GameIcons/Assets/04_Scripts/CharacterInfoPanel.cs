using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Colocar en el objeto "InfoManager" de cada escena de personaje.
// Requiere TextMeshPro. Antepone un título bilingüe (en negrita y color) a cada sección.
public class CharacterInfoPanel : MonoBehaviour
{
    [Header("Datos del personaje (arrastra el asset .asset aquí)")]
    public CharacterData data;

    [Header("Referencias UI")]
    public TMP_Text nameText;
    public TMP_Text originText;
    public TMP_Text historyText;
    public TMP_Text abilitiesText;
    public TMP_Text universeText;
    public TMP_Text creatorsText;
    public TMP_Text culturalImpactText;
    public Image portraitImage;

    [Header("Estilo de los títulos")]
    public string titleColorHex = "#E6B93C"; // dorado

    void OnEnable()
    {
        LanguageManager.OnLanguageChanged += Populate;
        Populate();
    }

    void OnDisable()
    {
        LanguageManager.OnLanguageChanged -= Populate;
    }

    // Devuelve: TÍTULO (negrita, color) + salto de línea + contenido
    string Section(string titleES, string titleEN, string bodyES, string bodyEN)
    {
        bool es = LanguageManager.IsSpanish;
        string title = es ? titleES : titleEN;
        string body = es ? bodyES : bodyEN;
        return $"<b><color={titleColorHex}>{title}</color></b>\n{body}";
    }

    void Populate()
    {
        if (data == null)
        {
            Debug.LogWarning("CharacterInfoPanel: no se asignó un CharacterData.");
            return;
        }

        bool es = LanguageManager.IsSpanish;

        nameText.text = $"<b><size=130%>{(es ? data.characterNameES : data.characterNameEN)}</size></b>";
        originText.text = Section("ORIGEN", "ORIGIN", data.originES, data.originEN);
        historyText.text = Section("HISTORIA", "HISTORY", data.historyES, data.historyEN);
        abilitiesText.text = Section("HABILIDADES", "ABILITIES", data.abilitiesES, data.abilitiesEN);
        universeText.text = Section("UNIVERSO", "UNIVERSE", data.universeES, data.universeEN);
        creatorsText.text = Section("CREADORES", "CREATORS", data.creatorsES, data.creatorsEN);
        culturalImpactText.text = Section("IMPACTO CULTURAL", "CULTURAL IMPACT",
            data.culturalImpactES, data.culturalImpactEN);

        if (portraitImage != null && data.portrait != null)
            portraitImage.sprite = data.portrait;
    }
}
