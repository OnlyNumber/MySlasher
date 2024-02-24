using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Move : State
{


    //ThirdPersonController personController;

    IMoveAble moveAble;

    IAttackAble attackAble;

    private List<string> _walks = new List<string>();

    private List<string> _runs = new List<string>();


    int checkDir;

    float lastSpeed;


    public Move(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        moveAble = StateManager.GetStateManagerOwner().GetComponent<IMoveAble>();

        attackAble= StateManager.GetStateManagerOwner().GetComponent<IAttackAble>();

        //personController = StateManager.GetThirdPersonController();

        _walks.Add(StaticAnimationFields.WALK_FORWARD);
        _walks.Add(StaticAnimationFields.WALK_FORWARD_RIGHT);
        _walks.Add(StaticAnimationFields.WALK_RIGHT);
        _walks.Add(StaticAnimationFields.WALK_BACK_RIGHT);
        _walks.Add(StaticAnimationFields.WALK_BACK);
        _walks.Add(StaticAnimationFields.WALK_BACK_LEFT);
        _walks.Add(StaticAnimationFields.WALK_LEFT);
        _walks.Add(StaticAnimationFields.WALK_FORWARD_LEFT);

        _runs.Add(StaticAnimationFields.RUN_FORWARD);
        _runs.Add(StaticAnimationFields.RUN_FORWARD_RIGHT);
        _runs.Add(StaticAnimationFields.RUN_RIGHT);
        _runs.Add(StaticAnimationFields.RUN_BACK_RIGHT);
        _runs.Add(StaticAnimationFields.RUN_BACK);
        _runs.Add(StaticAnimationFields.RUN_BACK_LEFT);
        _runs.Add(StaticAnimationFields.RUN_LEFT);
        _runs.Add(StaticAnimationFields.RUN_FORWARD_LEFT);


    }

    public override void OnEnter()
    {
        moveAble.AddOnChangeDirection(CheckDir);
        checkDir = -1;
        lastSpeed = -1;
    }


    public override void OnExit()
    {
        moveAble.RemoveOnChangeDirection(CheckDir);
    }

    public override void OnUpdate()
    {
        //Debug.Log("MOVE");
        
        if (moveAble.GetCurrentSpeed() == 0)
        {
            //Debug.Log("Change to Idle from Move");
            StateManager.ChangeState(StateEnum.idle);
        }
    }

    public void CheckDir(int dir)
    {
        if (checkDir == dir && lastSpeed == moveAble.GetCurrentSpeed() )
            return;

        if (moveAble.GetCurrentSpeed() < moveAble.GetCurrentSprintSpeed())
        {
            Animator.CrossFade(_walks[dir], 0.2f);
        
        }
        else
        {
            Animator.CrossFade(_runs[dir], 0.2f);
        }

        lastSpeed = moveAble.GetCurrentSpeed();
        checkDir = dir;
    }

}
