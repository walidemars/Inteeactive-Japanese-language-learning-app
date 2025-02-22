using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartTraining()
    {
        // Переход к сцене обучения (например, "TrainingScene")
        SceneManager.LoadScene(1);
    }

    public void OpenProfile()
    {
        // Переход к сцене профиля (например, "ProfileScene")
        SceneManager.LoadScene(2);
    }

    public void OpenSettings()
    {
        // Переход к сцене настроек (например, "SettingsScene")
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        // Закрытие приложения
        Application.Quit();
    }
}