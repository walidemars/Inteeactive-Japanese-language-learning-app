using UnityEngine;

public class LevelMapManager : MonoBehaviour
{
    public void RefreshMap()
    {
        foreach (var island in GameManager.Instance.UserProfile.UnlockedIslands)
        {
            // Активируем доступные острова
        }
    }

    public void OnLevelSelected(string levelID)
    {
        if (levelID.EndsWith("Theory"))
        {
            GameManager.Instance.LoadScene("TheoryScene");
        }
        else
        {
            GameManager.Instance.LoadScene("MiniGameScene");
        }
    }
}