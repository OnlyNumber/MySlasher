using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class Idle : State
{
    //ThirdPersonController personController;

    IMoveAble moveAble;

    public Idle(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        moveAble = StateManager.GetStateManagerOwner().GetComponent<IMoveAble>();

    }

    public override void OnEnter()
    {
        Animator.CrossFade(StaticAnimationFields.IDLE, 0.1f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        //Debug.Log("IDLE");

        if (moveAble.GetCurrentSpeed() > 0)
        {
            StateManager.ChangeState(StateEnum.walkF);


        }
    }


}
