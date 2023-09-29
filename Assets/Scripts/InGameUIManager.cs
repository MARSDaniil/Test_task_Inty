using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Localization.Settings;
public class InGameUIManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [Space]
    [Header("Lang button")]
    [SerializeField] Button langButtonEn;
    [SerializeField] Button langButtonRu;
    [SerializeField] Button exitButton;

    private Locale locale = Locale.ru;
    private void Awake() {
        Init();
    }

    private void Init() {
        slider.Init();
        langButtonRu.onClick.AddListener(SwitchLang);
        langButtonEn.onClick.AddListener(SwitchLang);
        exitButton.onClick.AddListener(ExitBoard);

        locale = (Locale)0;
        langButtonRu.gameObject.SetActive(false);
    }

    private void SwitchLang() {
        int newLocale = 0;
        switch ((int)locale) {
            case (0):
            newLocale = 1;
            langButtonEn.gameObject.SetActive(false);
            langButtonRu.gameObject.SetActive(true);
                break;
            case (1):
            langButtonRu.gameObject.SetActive(false);
            langButtonEn.gameObject.SetActive(true);
            newLocale = 0;
                break;
        }
        StartCoroutine(SetLocation(newLocale));
        locale = (Locale)newLocale;
    }

    private void ExitBoard() {
        Application.Quit();
    }
    IEnumerator SetLocation(int _localeID) {
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
    }

    public enum Locale {
        ru = 0,
        en
    }
}
