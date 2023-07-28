using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSaveSystem : ISaveSystem<PlayerState>
{
    private const string Key = "PlayerStateKey";
    void Start()
    {
        Load();
    }
    public  void Save(PlayerState date)
    {
        Save(key: Key, date: date);
    }
    public PlayerState Load()
    {
        return Load(key: Key);
    }
    public  void Clear()
    {
        Clear(key: Key);
    }
    protected void Save(string key, PlayerState date)
    {
        string json = JsonUtility.ToJson(date);
        PlayerPrefs.SetString(key: key, value: json);
    }
    protected PlayerState Load(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            return default;
        }
        string json = PlayerPrefs.GetString(key);
        var date = JsonUtility.FromJson<PlayerState>(json);
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

public class PlayerState
{
    public int Score;
    public int LifeState;
    public PlayerState(int score, int lifeState)
    {
        Score = score;
        LifeState = lifeState;
    }
    public PlayerState()
    {
        Score = 0;
        LifeState = 0;
    }
}