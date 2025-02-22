using System.Collections.Generic;

[System.Serializable]
public class UserProfile
{
    public string NativeLanguage = "Russian";
    public List<string> UnlockedIslands = new List<string>() { "Island1" };
    public Dictionary<string, LevelProgress> LevelData = new Dictionary<string, LevelProgress>();
    public List<Word> Dictionary = new List<Word>();
}

[System.Serializable]
public class LevelProgress
{
    public bool IsTheoryCompleted;
    public int MiniGameHighScore;
}

[System.Serializable]
public class Word
{
    public string Japanese;
    public string Translation;
}