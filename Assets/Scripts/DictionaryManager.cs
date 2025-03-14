using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager Instance;
    private List<GameObject> learnedIeroglyfs = new List<GameObject>(); // Список изученных иероглифов
    private List<GameObject> learnedWords = new List<GameObject>(); // Список изученных слов

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем между сценами
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Добавление иероглифа в словарик (если его там еще нет)
    public void AddIeroglyf(GameObject hieroglyph)
    {
        if (!learnedIeroglyfs.Contains(hieroglyph))
        {
            learnedIeroglyfs.Add(hieroglyph);
            Debug.Log($"Добавлено в словарик: {hieroglyph.name}");
        }
    }

    // Получить список изученных иероглифов
    public List<GameObject> GetLearnedHieroglyphs()
    {
        return learnedIeroglyfs;
    }
}
