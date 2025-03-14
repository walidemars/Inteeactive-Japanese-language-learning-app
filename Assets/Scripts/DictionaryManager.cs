using System.Collections.Generic;
using UnityEngine;

public class DictionaryManager : MonoBehaviour
{
    public static DictionaryManager Instance;
    private List<GameObject> learnedIeroglyfs = new List<GameObject>(); // ������ ��������� ����������
    private List<GameObject> learnedWords = new List<GameObject>(); // ������ ��������� ����

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ��������� ����� �������
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ���������� ��������� � �������� (���� ��� ��� ��� ���)
    public void AddIeroglyf(GameObject hieroglyph)
    {
        if (!learnedIeroglyfs.Contains(hieroglyph))
        {
            learnedIeroglyfs.Add(hieroglyph);
            Debug.Log($"��������� � ��������: {hieroglyph.name}");
        }
    }

    // �������� ������ ��������� ����������
    public List<GameObject> GetLearnedHieroglyphs()
    {
        return learnedIeroglyfs;
    }
}
