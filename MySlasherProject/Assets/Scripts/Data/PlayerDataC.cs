using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerDataC
{
    public float _musicVolume;

    public float _clipVolume;

    public float _masterVolume;

    /*public float MusicVolume
    {
        get
        {
            return _musicVolume;
        }

        set
        {
            _musicVolume = value;
        }
    }

    public float ClipVolume
    {
        get
        {
            return _clipVolume;
        }

        set
        {
            _clipVolume = value;
        }
    }
    public float MasterVolume
    {
        get
        {
            return _masterVolume;
        }

        set
        {
            _masterVolume = value;
        }
    }*/

    public int CurrentCharacter;

    public List<bool> OpenCharacter;

    public PlayerDataC()
    {
        Debug.Log("PlayerDataC");
        CurrentCharacter = 0;

        OpenCharacter = new List<bool>();

        OpenCharacter.Add(true);


    }
}
