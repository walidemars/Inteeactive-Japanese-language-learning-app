using System.Collections.Generic;
using NUnit.Framework;
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

    public void GoToProfile()
    {
        SceneManager.LoadScene("ProfileScene");
    }

    public void GoToIeroglifDictionary()
    {
        SceneManager.LoadScene("Ieroglif Dictionary");
        List<GameObject> ieroglifs = DictionaryManager.Instance.GetLearnedHieroglyphs();
        for (int i = 0; i < ieroglifs.Count; i++)
        {
            Debug.Log(ieroglifs[i]);
        }
    }

    public void StartLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
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
