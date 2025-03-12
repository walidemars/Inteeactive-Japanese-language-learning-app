using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }

    [Header("Game Settings")]
    [SerializeField] private int startPoints = 50;
    public GameObject spawnManagerObj;
    private SpawnManager spawnManager;

    [Header("UI References")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private string levelSelectionScene;
    //private LevelsManager levelManager;

    private bool gameOver;

    private int currentPoints;
    private string currentSceneName;
    InputAction addPointAction;
    InputAction subtractPointAction;


    void Start()
    {
        gameOver = false;
        InitializeGame();
        spawnManager = spawnManagerObj.GetComponent<SpawnManager>();
    }

    private void Update()
    {
        UpdatePointsDisplay();
        CheckWinCondition();
        CheckLoseCondition();
        //AddIeroglifDic();
        //TestGame();
    }

    private void InitializeGame()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        currentPoints = startPoints;
        UpdatePointsDisplay();
        Time.timeScale = 1f;

        if (winPanel) winPanel.SetActive(false);
        if (losePanel) losePanel.SetActive(false);
    }

    public void AddPoints(int amount)
    {
        currentPoints += amount;
        CheckWinCondition();
        UpdatePointsDisplay();
    }

    public void SubtractPoints(int amount)
    {
        currentPoints -= amount;
        CheckLoseCondition();
        UpdatePointsDisplay();
    }

    private void CheckWinCondition()
    {
        if (currentPoints >= 100)
        {
            WinGame();
        }
    }

    private void CheckLoseCondition()
    {
        if (currentPoints <= 0)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        Time.timeScale = 0f;
        if (winPanel) winPanel.SetActive(true);
        AddIeroglifDic();
        //LevelsManager.Instance.NextGame();

    }

    private void LoseGame()
    {
        GameOver();
        if (losePanel) losePanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneName);
    }

    public void ToNextGame()
    {
        LevelsManager.Instance.NextGame();
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(levelSelectionScene);
    }

    private void UpdatePointsDisplay()
    {
        if (pointsText) pointsText.text = $"Points: {currentPoints}";
    }

    public void GameOver()
    {
        gameOver = true;
        
        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }

        // Останавливаем игровой процесс, устанавливая timeScale в 0.
        Time.timeScale = 0;
        Debug.Log("Game Over!");
    }

    public void AddIeroglifDic()
    {
        if (LevelsManager.Instance.nextMiniGame >= LevelsManager.Instance.miniGames.Length)
        {
            for (int i = 0; i < spawnManager.ieroglifPrefabs.Length; i++)
            {
                DictionaryManager.Instance.AddIeroglyf(spawnManager.ieroglifPrefabs[i]);
            }
        }
    }
}
