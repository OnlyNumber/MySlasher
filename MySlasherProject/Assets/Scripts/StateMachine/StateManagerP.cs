using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class StateManagerP : StateManager
{
    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private GameObject personController;

    private State _currentState;

    public Dictionary<StateEnum, State> _states = new Dictionary<StateEnum, State>();

    private void Start()
    {
        _states.Add(StateEnum.idle, new Idle(_animator, this));
        _states.Add(StateEnum.walkF, new Move(_animator, this));
        _states.Add(StateEnum.attackCombo, new AttackCombo(_animator, this));
        _states.Add(StateEnum.attack, new Attack(_animator, this));


        _states.TryGetValue(StateEnum.idle, out _currentState);

        _currentState.OnEnter();

    }

    private void Update()
    {
        
        OnStateManagerUpdate?.Invoke();

        _currentState.OnUpdate();
    }

}
