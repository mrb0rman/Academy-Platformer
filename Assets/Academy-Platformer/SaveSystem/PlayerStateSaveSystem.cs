using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSaveSystem : PlayerPrefSaveSystem<PlayerState>
{
    private const string Key = "PlayerStateKey";
    void Start()
    {
        Load();
    }
    public override void Save(PlayerState date)
    {
        Save(key: Key, date: date);
    }
    public override PlayerState Load()
    {
        return Load(key: Key);
    }
    public override void Clear()
    {
        Clear(key: Key);
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