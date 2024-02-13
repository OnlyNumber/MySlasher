using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class Idle : State
{
    ThirdPersonController personController;


    public Idle(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        personController = StateManager.GetThirdPersonController();

    }

    public override void OnEnter()
    {
        Debug.Log("Idle");
        Animator.Play(StaticFields.IDLE);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (personController.TargetSpeed > 0)
        {
            StateManager.ChangeState(StateManager.StateEnum.walkF);


        }
    }


}
