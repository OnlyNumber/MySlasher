using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Move : State
{


    ThirdPersonController personController;

    private List<string> _walks = new List<string>();


    public Move(Animator animator, StateManager stateManager) : base(animator,stateManager)
    {
        personController = StateManager.GetThirdPersonController();

        _walks.Add(StaticFields.WALK_FORWARD);
        _walks.Add(StaticFields.WALK_RIGHT);
        _walks.Add(StaticFields.WALK_BACK);
        _walks.Add(StaticFields.WALK_LEFT);



    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (personController.TargetSpeed < personController.SprintSpeed && personController.TargetSpeed > 0)
        {
            Animator.Play(_walks[(int)personController.MoveDirectionIndex]);
        }
        else if (personController.TargetSpeed > 0)
        {
            Animator.Play(StaticFields.RUN_FORWARD);

        }
        else
        {
            StateManager.ChangeState(StateManager.StateEnum.idle);
        }

    }
}
