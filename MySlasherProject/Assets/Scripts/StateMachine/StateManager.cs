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

    private State _currentState;

    private Dictionary<StateEnum, State> _states = new Dictionary<StateEnum, State>();

    private void Start()
    {
        _states.Add(StateEnum.idle, new Idle(_animator, this));
        _states.Add(StateEnum.walkF, new Move(_animator, this));

        _states.TryGetValue(StateEnum.idle, out _currentState);

        _currentState.OnEnter();
    }

    private void Update()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(StateEnum state)
    {
        _currentState.OnExit();

       _states.TryGetValue(state, out _currentState);

        _currentState.OnEnter();


    }    

    public ThirdPersonController GetThirdPersonController()
    {
        return personController;
    }

    public enum StateEnum
    {
        idle,
        walkF
    };

}
