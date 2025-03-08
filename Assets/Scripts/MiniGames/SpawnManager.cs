using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public GameObject[] ieroglifPrefabs;
    public GameObject platformPrefab;
    public float delayTime = 1;
    public float intervalTime = 3;
    public float spawnOffset = 1f;

    private Vector3 spawnPos = new Vector3(25, 0, 0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObject", delayTime, intervalTime / 2);
        InvokeRepeating("SpawnPlatform", delayTime, intervalTime);
    }

    void SpawnObject()
    {
        if (obstaclePrefabs == null)
        {
            Debug.LogWarning("Префаб для спавна не назначен!");
            return;
        }

        // Определяем правый край экрана (точка в середине по Y).
        Vector3 screenRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.5f));

        float spawnY;
        int spawnIndex = Random.Range(0, 2);
        if (spawnIndex == 0)
        {
            spawnY = -2.3f;
        }
        else
        {
            spawnY = 0.75f;
        }

        // Рассчитываем позицию спавна за правой границей экрана.
        Vector3 spawnPosition = new Vector3(screenRight.x + spawnOffset, spawnY, 0);

        // Создаем объект.
        Instantiate(obstaclePrefabs[Random.Range(0, 2)], spawnPosition, Quaternion.identity);
    }

    void SpawnPlatform()
    {
        if (platformPrefab == null)
        {
            Debug.LogWarning("Префаб для спавна платформы не назначен!");
            return;
        }

        // Определяем правый край экрана (точка в середине по Y).
        Vector3 screenRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 0.5f, 0));

        float spawnY = -0.25f;

        // Рассчитываем позицию спавна за правой границей экрана.
        Vector2 spawnPosition = new Vector2(screenRight.x + spawnOffset, spawnY);

        // Создаем объект.
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
