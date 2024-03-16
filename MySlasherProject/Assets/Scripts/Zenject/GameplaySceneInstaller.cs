using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using StarterAssets;

public class GameplaySceneInstaller : MonoInstaller
{

    [SerializeField]
    private List<CharacterInfo> _charactersInfos;

    private ThirdPersonController _player;

    [SerializeField]
    private PlayerUI _playerUIPrefabed;

    [Inject] public void Initialize(PlayerData playerData)
    {

    }

    public override void InstallBindings()
    {
        Debug.Log("Install bindings");
        Container.BindInterfacesAndSelfTo<PlayerUI>().FromInstance(_playerUIPrefabed).AsSingle();

        _player = Container.InstantiatePrefabForComponent<ThirdPersonController>(_charactersInfos[0].personController, Vector3.zero, Quaternion.identity, null);

        _playerUIPrefabed.Initialize(_player);


        Container.BindInterfacesAndSelfTo<ThirdPersonController>().FromInstance(_player).AsSingle();


    }
}
