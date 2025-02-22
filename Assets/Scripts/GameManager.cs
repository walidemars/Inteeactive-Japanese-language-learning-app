using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UserProfile UserProfile { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadUserData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void LoadUserData()
    {
        // �������� �� �����/PlayerPrefs
        UserProfile = new UserProfile();
    }

    public void SaveProgress()
    {
        // ���������� ���������
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}