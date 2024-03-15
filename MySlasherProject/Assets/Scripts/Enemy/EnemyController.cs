using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class EnemyController : MonoBehaviour, IMoveAble, IAttackAble, IStunAble, ITargetFindAble
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

    [SerializeField]
    private float _attackDistance;

    private float _angle;

    private bool _isRotating = true;

    private EnemySpawner _enemySpawner;

    public float _currentDelayTime;

    private void Start()
    {
        OnEnemyUpdate += CheckDistance;
        _healthHandler.OnHealthChange += CheckDeath;
        _stateManager = GetComponent<StateManager>();

        _stateManager.GetState(StateEnum.attack).OnStateExit += ChangeToSearchState;

    }

    public void Initialize(Transform player, EnemySpawner enemySpawner)
    {
        _player = player;
        _enemySpawner = enemySpawner;
    }

    public void OnUpdate()
    {
        if (_isStunned)
        {
            return;
        }

        FindingAngle();

        OnEnemyUpdate?.Invoke();
        
        if (!_isAttacking)
        {


            _currentTimeBetweenAttack -= Time.deltaTime;
            Move();

        }

        if (_isRotating)
        {
            Rotating();
        }

    }

    public void StopRotating()
    {
        _isRotating = false;
    }

    public void ContinueRotating()
    {
        _isRotating = true;
    }

    bool firstAttack;

    public void ChangeToAttackState()
    {

        Debug.Log("Changer attack");

        OnEnemyUpdate -= CheckDistance;
        OnEnemyUpdate += Attacking;

        _preapreAttackParticles.Play();

        firstAttack = true;

        _currentDelayTime = _delayBeforeAttack;

        SetAttackingState(true);

    }


    public void Attacking()
    {
        //_preapreAttackParticles.Play();
        _currentDelayTime -= Time.deltaTime;


        if (_currentDelayTime <= 0 && firstAttack)
        {
            SetAttackingState(true);

            _stateManager.ChangeState(StateEnum.attack);

            _currentTimeBetweenAttack = _timeBetweenAttack;

            firstAttack = false;
        }
    }

    public void ChangeToSearchState()
    {
        Debug.Log("Changer search");


        OnEnemyUpdate -= Attacking;
        OnEnemyUpdate += CheckDistance;
    }

    public void CheckDistance()
    {
        if (_player == null)
        {
            _currentSpeed = 0;
            return;
        }

        //OnUpdateEnemy?.Invoke();

        if (Vector3.Distance(transform.position, _player.position) < _attackDistance)
        {
            _currentSpeed = 0;
            if (_currentTimeBetweenAttack <= 0)
            {

                Debug.Log("Nu pochemu");
                ChangeToAttackState();

                //StartCoroutine(PrepareAttack(_delayBeforeAttack));
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

    public void FindingAngle()
    {
        Vector3 targetDirection;

        targetDirection = _player.position - transform.position;
        _angle = Mathf.Atan2(targetDirection.normalized.x, targetDirection.normalized.z) * Mathf.Rad2Deg; ;
    }

    public void Rotating()
    {
        transform.rotation = Quaternion.Euler(0, _angle, 0);
    }

    public void Move()
    {
        if (_player == null)
        {
            return;
        }

        Vector3 targetDirection;

        targetDirection = _player.position - transform.position;

        _characterController.Move(targetDirection.normalized * _currentSpeed * Time.deltaTime);

        OnChangeDirectionIndex?.Invoke(0);

    }

    public void Stun()
    {
        _stateManager.ChangeState(StateEnum.stun);
    }

    #region implementing Interfaces

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
            //OnEnemyUpdate += CheckDistance;
        }
        else
        {
            //OnEnemyUpdate -= CheckDistance;

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

            gameObject.layer = LayerMask.NameToLayer(StaticFields.INVINSIBLE_LAYER);
            _stateManager.ChangeState(StateEnum.death);
        }



    }

    public void StartDeath()
    {
        _enemySpawner.RemoveEnemy(this);
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

    public string GetCurrentAttackName()
    {
        return StaticAnimationFields.ATTACK_1;
    }

    public Vector3 GetTargetPosition()
    {
        return _player.position;
    }
    #endregion
}
