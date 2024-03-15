using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private List<CharacterInfo> _charactersInfos;

    private ThirdPersonController _player;

    [SerializeField]
    private List<Image> _icons;

    [SerializeField]
    private EnemySpawner _enemySpawner;

    [SerializeField]
    private PauseControl _pauseControl;

    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera _virtualCamera;

    [SerializeField]
    private HealthPlayerUI _healthUI;


    private void Start()
    {
        DataControl.Instance.OnDataLoaded += Initialize;
    }

    public void Initialize(PlayerDataC playerInfo)
    {
        SpawnPlayer(playerInfo.CurrentCharacter);

        _virtualCamera.Follow = _player.transform;
        _virtualCamera.LookAt = _player.transform;

        _player.GetComponent<SkillControl>().Initialize(_icons);
        _healthUI.Initialize(_player.GetComponent<HealthHandler>());

        _pauseControl.Initialize(_player.GetComponent<StarterAssetsInputs>());

        _enemySpawner.Initialize(_player.transform);
        _enemySpawner.SpawnWave();
    }
    
    private void SpawnPlayer(int index)
    {
        _player = Instantiate(_charactersInfos[index].personController, Vector3.zero, Quaternion.identity);
    }

}
