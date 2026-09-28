using UnityEngine;

// Crea un asset desde: Assets > Create > Video Game Icons > Character Data
[CreateAssetMenu(fileName = "NewCharacterData", menuName = "Video Game Icons/Character Data")]
public class CharacterData : ScriptableObject
{
    [Header("Identificación / Identification")]
    public string characterNameEN = "Character Name";
    public string characterNameES = "Nombre del Personaje";
    public Sprite portrait;

    [Tooltip("Nombre EXACTO de la escena de este personaje (debe coincidir con Build Settings)")]
    public string sceneName;

    [Header("Origen / Origin")]
    [TextArea(3, 8)] public string originEN;
    [TextArea(3, 8)] public string originES;

    [Header("Historia / History")]
    [TextArea(3, 8)] public string historyEN;
    [TextArea(3, 8)] public string historyES;

    [Header("Habilidades / Abilities")]
    [TextArea(3, 8)] public string abilitiesEN;
    [TextArea(3, 8)] public string abilitiesES;

    [Header("Universo / Universe")]
    [TextArea(3, 8)] public string universeEN;
    [TextArea(3, 8)] public string universeES;

    [Header("Creadores / Creators")]
    [TextArea(2, 5)] public string creatorsEN;
    [TextArea(2, 5)] public string creatorsES;

    [Header("Impacto Cultural / Cultural Impact")]
    [TextArea(3, 8)] public string culturalImpactEN;
    [TextArea(3, 8)] public string culturalImpactES;
}
