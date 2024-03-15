using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : State
{
    private IStunAble _stunAble;


    public Death(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {

        _stunAble = StateManager.GetStateManagerOwner().GetComponent<IStunAble>();

        //_personController = StateManager.GetThirdPersonController();
    }

    public override void OnEnter()
    {
        Debug.Log("Start death");
        _stunAble.SetStun(true);
        Animator.Play(StaticAnimationFields.DEATH);
    }

    public override void OnExit()
    {
        
    }


    public override void OnUpdate()
    {

    }
}
