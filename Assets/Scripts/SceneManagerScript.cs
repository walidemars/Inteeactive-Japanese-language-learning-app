using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void StartLearning()
    {
        SceneManager.LoadScene("MapScene");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartHiragana()
    {
        SceneManager.LoadScene("HiraganaScene");
    }

    public void StartKatakana()
    {
        SceneManager.LoadScene("KatakanaScene");
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
