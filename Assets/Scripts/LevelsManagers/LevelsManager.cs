
using UnityEngine;
using UnityEngine.SceneManagement;

// Управление переключением мини играми в уровне
public class LevelsManager : MonoBehaviour
{
    public static LevelsManager Instance { get; private set; }

    [SerializeField] private int currentMiniGame;
    [SerializeField] private int nextMiniGame;
    [SerializeField] private string levelSelectionScene;

    public string[] miniGames;
    
    void Awake()
    {
        // синглтон
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    void Start()
    {
        currentMiniGame = 0;
        nextMiniGame = currentMiniGame + 1;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == levelSelectionScene)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void NextGame()
    {    
        if (nextMiniGame < miniGames.Length)
        {
            SceneManager.LoadScene(miniGames[nextMiniGame]);
            
            currentMiniGame++;
            nextMiniGame = currentMiniGame + 1;
        }
        else
        {
            currentMiniGame = 0;
            nextMiniGame = currentMiniGame + 1;
            SceneManager.LoadScene("HiraganaScene");
        }       
    }
   
}
