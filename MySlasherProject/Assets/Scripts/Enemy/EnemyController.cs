using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IMoveAble, IAttackAble, IStunAble
{
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
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

    [SerializeField]
    private bool _isAttacking = false;

    private bool _isAttackInput;

    [SerializeField]
    private float _timeStun;

    private bool _isStunned;

    [SerializeField]
    private float _damage;

    [SerializeField]
    private float _delayBeforeAttack;

    [SerializeField]
    private HealthHandler _healthHandler;

    [SerializeField]
    private ParticleSystem _preapreAttackParticles;


    private void Start()
    {
        OnEnemyUpdate += CheckDistance;
        _healthHandler.OnHealthChange += CheckDeath;
        _stateManager = GetComponent<StateManager>();
    }


    // Update is called once per frame
    public void OnUpdate()
    {
        if (_isStunned)
        {
            return;
        }

        if (!_isAttacking)
        {
            _currentTimeBetweenAttack -= Time.deltaTime;
            OnEnemyUpdate?.Invoke();
            Move();
        }
    }

    public void CheckDistance()
    {
        if (_player == null)
        {
            _currentSpeed = 0;
            return;
        }

        if (Vector3.Distance(transform.position, _player.position) < 2)
        {
            _currentSpeed = 0;
            if (_currentTimeBetweenAttack <= 0)
            {
                StartCoroutine(PrepareAttack(_delayBeforeAttack));
                //_stateManager.ChangeState(StateEnum.attack);
                //_currentTimeBetweenAttack = _timeBetweenAttack;
            }
        }
        else
        {
            _currentSpeed = _speed;
        }
    }

    private IEnumerator PrepareAttack(float delay)
    {
        _preapreAttackParticles.Play();

        SetAttackingState(true);

        yield return new WaitForSeconds(delay);

        _stateManager.ChangeState(StateEnum.attack);

        _currentTimeBetweenAttack = _timeBetweenAttack;


    }


    public void Move()
    {
        if (_player == null)
        {
            return;
        }

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

    public void Stun()
    {
        _stateManager.ChangeState(StateEnum.stun);
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

    public float GetStunTime()
    {
        return _timeStun;
    }

    public void SetStun(bool state)
    {
        _isStunned = state;
    }

    public void GoToStunState()
    {
        _stateManager.ChangeState(StateEnum.stun);
    }
    public float GetDamage()
    {
        return _damage;
    }

    public void CheckDeath(int health)
    {
        if (health <= 0)
        {
            //Debug.Log("dead");
            _stateManager.ChangeState(StateEnum.death);
        }
    }

    public void StartDeath()
    {
        Destroy(gameObject);
    }

    public int GetCurrentDirection()
    {
        return 0;
    }

    public int GetAmountOfDirections()
    {
        return 1;
    }
}
