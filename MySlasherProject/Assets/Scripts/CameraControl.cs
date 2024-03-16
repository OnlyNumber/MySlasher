using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using StarterAssets;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private Cinemachine.CinemachineVirtualCamera _virtualCamera;

    [Inject]
    public void Initialize(ThirdPersonController player)
    {
        Debug.Log("First Enemy spawner");

        _virtualCamera.LookAt = player.transform;

        _virtualCamera.Follow = player.transform;

    }

}
