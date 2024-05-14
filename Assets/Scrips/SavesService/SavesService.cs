using UnityEngine;

public class SavesService
{
    private static SavesService _instance;

    public static SavesService Instance
    {  
        get 
        { 
            _instance ??= new SavesService();
            return _instance; 
        } 
    }

    public T Load<T>() where T : ISaveData, new()
    {
        if (PlayerPrefs.HasKey(nameof(T)))
        {
            var json = PlayerPrefs.GetString(nameof(T));
            return JsonUtility.FromJson<T>(json);
        }

        return new T();
    }

    public void Save<T>(T saveData) where T : ISaveData
    {
        if (saveData == null)
        {
            Debug.LogError($"[SavesService] saveData {nameof(T)} is null");
            return;
        }

        PlayerPrefs.SetString(nameof(T), JsonUtility.ToJson(saveData));
    }
}
