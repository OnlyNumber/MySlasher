using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using Zenject;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;

    [SerializeField]
    private Slider _sliderMasterSound;

    [SerializeField]
    private Slider _sliderMusic;

    [SerializeField]
    private Slider _sliderClipSound;

    [SerializeField]
    private List<AudioClip> _backgroundMusics;

    [SerializeField]
    private AudioSource _backgroundMusicSource;

    public Action<bool> OnClipSoundChange;

    public Action<bool> OnMusicSoundChange;

    private PlayerData _playerData;

    private void Start()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _backgroundMusicSource.Play();

        //DataControl.Instance.OnDataLoaded += Initialize;

    }

    [Inject]
    public void Initialize(PlayerData playerData)
    {
        Debug.Log("Sound has been Initialized");


        _playerData = playerData;

        _sliderMusic.value = playerData._musicVolume;

        _sliderClipSound.value = playerData._clipVolume;

        _sliderMasterSound.value = playerData._masterVolume;

        Debug.Log(playerData._musicVolume + " + " + playerData._clipVolume + " + " + playerData._masterVolume);

        Debug.Log(playerData._musicVolume);


        _backgroundMusicSource.clip = _backgroundMusics[UnityEngine.Random.Range(0, _backgroundMusics.Count)];
    }

    public void Update()
    {
        if (_backgroundMusicSource.clip != null && !_backgroundMusicSource.isPlaying)
        {

            _backgroundMusicSource.clip = _backgroundMusics[UnityEngine.Random.Range(0, _backgroundMusics.Count)];
            _backgroundMusicSource.Play();
        }
    }


    public void PlayAudioClip(AudioClip clip)
    {
        //AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, _playerData.ClipVolume * _playerData.MasterVolume);
    }

    public void SetSound(int soundType)
    {
        switch ((TypeSound)soundType)
        {
            case TypeSound.clip:
                {
                    //SetMusicOpposite(ref PlayerDataManager.Instance.CurrentData.VolumeClip);
                    //OnClipSoundChange?.Invoke(FromIntToBool(PlayerDataManager.Instance.CurrentData.VolumeClip));

                    break;
                }
            case TypeSound.music:
                {
                    /*SetMusicOpposite(ref PlayerDataManager.Instance.CurrentData.VolumeMusic);
                    _backgroundMusic.volume = PlayerDataManager.Instance.CurrentData.VolumeMusic;
                    OnMusicSoundChange?.Invoke(FromIntToBool(PlayerDataManager.Instance.CurrentData.VolumeMusic));*/
                    break;
                }
        }
    }

    public void SetMuic()
    {
        _playerData._musicVolume = _sliderMusic.value;

        _backgroundMusicSource.volume = _playerData._musicVolume * _playerData._masterVolume;
    }

    public void SetClipSound()
    {
        _playerData._clipVolume = _sliderClipSound.value;
    }

    public void SetMasterSound()
    {
        if (_playerData == null)
        {
            Debug.Log("_playerData == null");
        }

        _playerData._masterVolume = _sliderMasterSound.value;
        _backgroundMusicSource.volume = _playerData._musicVolume * _playerData._masterVolume;

    }


    public bool FromIntToBool(int i)
    {
        return i == 0 ? false : true;
    }


    public void SetMusicOpposite(ref int volume)
    {
        if (volume == 1)
        {
            volume = 0;
        }
        else
        {
            volume = 1;
        }

        //_defaultMusic.volume = IsMusic;

        //OnChangeVolume?.Invoke();
    }

}

public enum TypeSound
{
    clip,
    music
}