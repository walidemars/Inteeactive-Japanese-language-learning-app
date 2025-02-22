using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public Dropdown languageDropdown;  // Ссылка на Dropdown для выбора языка

    void Start()
    {
        // Загружаем сохраненный язык при старте
        if (PlayerPrefs.HasKey("Language"))
        {
            int savedLanguageIndex = PlayerPrefs.GetInt("Language");
            languageDropdown.value = savedLanguageIndex;
        }
    }

    public void SaveLanguageSetting()
    {
        // Сохраняем выбранный язык
        PlayerPrefs.SetInt("Language", languageDropdown.value);
        PlayerPrefs.Save();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}