using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IMoveAble, IAttackAble
{
    [SerializeField]
    private CharacterController _characterController;

    private StateManager _stateManager;

    [SerializeField]
    private float _currentSpeed;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private Transform _player;

    public System.Action<int> OnChangeDirectionIndex;

    public bool wtf;
    [SerializeField]
    private float _timeBetweenAttack;

    private float _currentTimeBetweenAttack;

    private System.Action OnEnemyUpdate;

    private bool _isAttacking;

    private bool _isAttackInput;

    private void Start()
    {
        OnEnemyUpdate += CheckDistance;
    }

    // Update is called once per frame
    public void OnUpdate()
    {

        OnEnemyUpdate?.Invoke();
        _currentTimeBetweenAttack -= Time.deltaTime;
        if(!_isAttacking)
        Move();
    }

    public void CheckDistance()
    {
        if (Vector3.Distance(transform.position, _player.position) < 1)
        {
            _currentSpeed = 0;
            if (_currentTimeBetweenAttack <= 0)
            {
                GetComponent<StateManager>().ChangeState(StateEnum.attackCombo);
                _currentTimeBetweenAttack = _timeBetweenAttack;
            }
        }
        else
        {
            _currentSpeed = _speed;
        }
    }


    public void Move()
    {
        Vector3 targetDirection;
        float angle;

        targetDirection = _player.position - transform.position;
        angle = Mathf.Atan2(targetDirection.normalized.x, targetDirection.normalized.z) * Mathf.Rad2Deg; ;

        _characterController.Move(Vector3.zero);

        _characterController.Move(targetDirection.normalized * _currentSpeed * Time.deltaTime /*+ new Vector3(0.0f, -2, 0.0f) * Time.deltaTime*/);
        transform.rotation = Quaternion.Euler(0, angle, 0);

        //
        OnChangeDirectionIndex?.Invoke(0);

    }

    public bool GetAttackingState()
    {
        return _isAttacking;
    }

    public float GetCurrentSpeed()
    {
        return _currentSpeed;
    }

    public float GetCurrentSprintSpeed()
    {
        return 999;
    }

    public void AddOnChangeDirection(System.Action<int> addAction)
    {
        OnChangeDirectionIndex += addAction;
    }

    public void RemoveOnChangeDirection(System.Action<int> removeAction)
    {
        OnChangeDirectionIndex -= removeAction;

    }

    public void SetAttackingState(bool state)
    {
        _isAttacking = state;
    }

    public void SetAttackInput(bool state)
    {
        _isAttackInput = state;
    }

    public bool GetAttackInput()
    {
        return _isAttackInput;
    }

    public void SetCheckAttackState(bool state)
    {
        if (state)
        {
            OnEnemyUpdate += CheckDistance;
        }
        else
        {
            OnEnemyUpdate -= CheckDistance;

        }
    }
}
