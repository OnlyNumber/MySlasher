using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataControl : MonoBehaviour
{
    [SerializeField]
    private PlayerData _playerData;

    public System.Action<PlayerData> OnDataLoaded;

    public static DataControl Instance;

    private void Awake()
    {
        if (Instance == null)
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
        if (PlayerPrefs.HasKey(StaticFields.PLAYER_DATA))
        {
            Debug.Log("has key start");
        }


        LoadData();

    }

    [ContextMenu("Check")]
    public void Check()
    {
        if (PlayerPrefs.HasKey(StaticFields.PLAYER_DATA))
        {
            Debug.Log("has key");
        }
    }

    private void LoadData()
    {
        _playerData = SaveManager.Load<PlayerData>(StaticFields.PLAYER_DATA);

        OnDataLoaded?.Invoke(_playerData);
    }

    private void OnApplicationQuit()
    {
        SaveManager.Save(_playerData, StaticFields.PLAYER_DATA);
    }

}


