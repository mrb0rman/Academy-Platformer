using System;
using UnityEngine;

public abstract class PlayerPrefSaveSystem<T>:MonoBehaviour, ISaveSystem<T>
{
    public abstract void Save(T date);
    public abstract T Load();
    public abstract void Clear();
    protected void Save(string key, T date)
    {
        string json = JsonUtility.ToJson(date);
        PlayerPrefs.SetString(key: key, value: json);
    }
    protected T Load(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return default;
        }
        string json = PlayerPrefs.GetString(key);
        var date = JsonUtility.FromJson<T>(json);
        return date;
    }
    protected void Clear(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            PlayerPrefs.DeleteKey(key);
        }
    }
}

