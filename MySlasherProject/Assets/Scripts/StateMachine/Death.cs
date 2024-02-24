using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : State
{
    IStunAble stunAble;


    public Death(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {

        stunAble = StateManager.GetStateManagerOwner().GetComponent<IStunAble>();

        //_personController = StateManager.GetThirdPersonController();
    }

    public override void OnEnter()
    {
        stunAble.SetStun(true);
        Animator.CrossFade(StaticAnimationFields.DEATH, 0.1f);
    }

    public override void OnExit()
    {
        
    }


    public override void OnUpdate()
    {

    }
}
