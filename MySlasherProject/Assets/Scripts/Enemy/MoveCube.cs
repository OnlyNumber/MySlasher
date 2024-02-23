using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    public float speed;

    private void Update()
    {
        characterController.Move(new Vector3(1, 0, 0) * speed * Time.deltaTime);
    }
}
