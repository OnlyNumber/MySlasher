using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class StateManager : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private ThirdPersonController personController;

    public StarterAssetsInputs Input;

    private State _currentState;

    private Dictionary<StateEnum, State> _states = new Dictionary<StateEnum, State>();

    private void Start()
    {
        Input = GetComponent<StarterAssetsInputs>();

        _states.Add(StateEnum.idle, new Idle(_animator, this));
        _states.Add(StateEnum.walkF, new Move(_animator, this));
        _states.Add(StateEnum.attack, new Attack(_animator, this));

        _states.TryGetValue(StateEnum.idle, out _currentState);

        _currentState.OnEnter();

        OnStateManagerUpdate += CheckAttack;

    }

    public System.Action OnStateManagerUpdate;

    private void Update()
    {
        OnStateManagerUpdate?.Invoke();

        _currentState.OnUpdate();
    }

    public void ChangeState(StateEnum state)
    {
        _currentState.OnExit();

       _states.TryGetValue(state, out _currentState);

       _currentState.OnEnter();


    }    

    public void CheckAttack()
    {
        if (Input.attack == true)
        {
            ChangeState(StateEnum.attack);
            Input.attack = false;
        }
    }

    public ThirdPersonController GetThirdPersonController()
    {
        return personController;
    }

    public enum StateEnum
    {
        idle,
        walkF,
        attack
    };

}
