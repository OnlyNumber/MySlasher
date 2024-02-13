using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Animator Animator;

    protected StateManager StateManager;


    public State(Animator animator, StateManager stateManager)
    {
        Animator = animator;
        StateManager = stateManager;
    }

    public abstract void OnEnter();

    public abstract void OnUpdate();

    public abstract void OnExit();


}
