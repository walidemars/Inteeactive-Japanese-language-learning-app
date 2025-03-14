using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // Изменили пространство имен с UIElements на UI

public class DictionaryUI : MonoBehaviour
{
    public GameObject dictionaryPanel;
    public Transform contentArea;
    public GameObject hieroglyphSlotPrefab;

    void Start()
    {
        PopulateDictionary();
    }

    void PopulateDictionary()
    {
        foreach (Transform child in contentArea)
        {
            Destroy(child.gameObject);
        }

        List<GameObject> learnedHieroglyphs = DictionaryManager.Instance.GetLearnedHieroglyphs();

        foreach (GameObject hieroglyph in learnedHieroglyphs)
        {
            GameObject slot = Instantiate(hieroglyphSlotPrefab, contentArea);

            // Используем UnityEngine.UI.Image
            Image img = slot.GetComponent<Image>();
            if (img == null) img = slot.GetComponentInChildren<Image>();

            // Добавляем проверку компонента у иероглифа
            SpriteRenderer hieroglyphRenderer = hieroglyph.GetComponent<SpriteRenderer>();

            if (img != null && hieroglyphRenderer != null)
            {
                img.sprite = hieroglyphRenderer.sprite;
            }
            else
            {
                Debug.LogWarning($"Ошибка в слоте: {hieroglyph.name}. " +
                    $"Image: {img != null}, Renderer: {hieroglyphRenderer != null}");
            }
        }
    }
}