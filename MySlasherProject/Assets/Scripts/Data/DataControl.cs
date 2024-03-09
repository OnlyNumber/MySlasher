using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour
{
    private PlayerData _playerData;

    public System.Action<PlayerData> OnDataLoaded;

    public static DataControl Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        } 
        
    }

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        _playerData = SaveManager.Load<PlayerData>(StaticFields.PLAYER_DATA);

        OnDataLoaded?.Invoke(_playerData);
    }

}

public class PlayerData
{
    public float MusicVolume;

    public float SoundVolume;

    public int CurrentCharacter;

    public List<bool> OpenCharacter;

    public PlayerData()
    {
        MusicVolume = 1;

        SoundVolume = 1;

        CurrentCharacter = 0;

        OpenCharacter = new List<bool>();

        OpenCharacter.Add(true);

        
    }

}
