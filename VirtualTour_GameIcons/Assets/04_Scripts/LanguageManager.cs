using System;
using UnityEngine;

// Guarda el idioma elegido (se mantiene entre escenas y entre sesiones).
// No se coloca en ningún objeto: es una clase estática que usan los otros scripts.
public static class LanguageManager
{
    private const string Key = "isSpanish";

    // Los textos se suscriben a este evento para actualizarse cuando cambie el idioma
    public static event Action OnLanguageChanged;

    // Por defecto la app arranca en español
    public static bool IsSpanish
    {
        get => PlayerPrefs.GetInt(Key, 1) == 1;
        private set
        {
            PlayerPrefs.SetInt(Key, value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static void Toggle()
    {
        IsSpanish = !IsSpanish;
        OnLanguageChanged?.Invoke();
    }
}
