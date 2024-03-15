using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataControl : MonoBehaviour
{
    [SerializeField]
    private PlayerDataC _playerData;

    public System.Action<PlayerDataC> OnDataLoaded;

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

    private void Update()
    {
        /*Debug.Log("_musicVolume volume: " + _playerData._musicVolume);
        Debug.Log("_clipVolume volume: " + _playerData._clipVolume);
        Debug.Log("_masterVolume volume: " + _playerData._masterVolume);
        Debug.Log("_masterVolumeTest volume: " + _playerData._masterVolumeTest);*/


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
        _playerData = SaveManager.Load<PlayerDataC>(StaticFields.PLAYER_DATA);

        OnDataLoaded?.Invoke(_playerData);
    }

    /*public float GetMusicVolume()
    {
        return _playerData.MusicVolume;
    }

    public void SetMusicVolume(float value)
    {
        _playerData.MusicVolume = value;
    }*/

    private void OnApplicationQuit()
    {
        SaveManager.Save(_playerData, StaticFields.PLAYER_DATA);
    }

}


