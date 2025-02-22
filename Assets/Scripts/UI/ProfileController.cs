using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour
{
    public TextMeshProUGUI progressText;
    public TextMeshProUGUI vocabularyText;

    void Start()
    {
        // Отображаем прогресс
        UpdateProfile();
    }

    public void UpdateProfile()
    {
        // Здесь ты можешь взять прогресс пользователя из PlayerPrefs или базы данных
        int progress = PlayerPrefs.GetInt("Progress", 0);
        progressText.text = "Прогресс: " + progress + "%";

        // Отображаем словарик (пример)
        string vocabulary = PlayerPrefs.GetString("Vocabulary", "Нет слов");
        vocabularyText.text = "Словарик: " + vocabulary;
    }
    
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}