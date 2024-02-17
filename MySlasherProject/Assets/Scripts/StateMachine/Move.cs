using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Move : State
{


    ThirdPersonController personController;

    private List<string> _walks = new List<string>();

    private List<string> _runs = new List<string>();


    int checkDir;

    float lastSpeed;


    public Move(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        personController = StateManager.GetThirdPersonController();

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
        personController.OnChangeDirectionIndex += CheckDir;
        checkDir = -1;
        lastSpeed = -1;
    }


    public override void OnExit()
    {
        personController.OnChangeDirectionIndex -= CheckDir;
        //personController.checkDir = -1;
    }

    public override void OnUpdate()
    {
        /*if (personController.TargetSpeed < personController.SprintSpeed && personController.TargetSpeed > 0)
        {
            Animator.Play(_walks[(int)personController.MoveDirectionIndex]);

            //Animator.CrossFade(_walks[(int)personController.MoveDirectionIndex], 0,0,0,1f);
            if(!Animator.IsInTransition(0))
            Animator.CrossFade(_walks[(int)personController.MoveDirectionIndex], 0.25f,0, 0.25f, 0.25f);
        }
        else if (personController.TargetSpeed > 0)
        {
            Animator.Play(StaticAnimationFields.RUN_FORWARD);
            //Animator.CrossFade()
        }*/
        if (personController.TargetSpeed == 0)
        {
            StateManager.ChangeState(StateManager.StateEnum.idle);
        }
    }

    public void CheckDir(int dir)
    {
        if (checkDir == dir && lastSpeed == personController.TargetSpeed)
            return;

        if (personController.TargetSpeed < personController.SprintSpeed)
        {
            //Debug.Log(dir);
            //Animator.Play(_walks[(int)personController.MoveDirectionIndex]);

            //Animator.CrossFade(_walks[(int)personController.MoveDirectionIndex], 0,0,0,1f);
            //if (!Animator.IsInTransition(0))
            
            Animator.CrossFade(_walks[dir], 0.2f/*, 0, 0.25f, 0.25f*/);
        
        }
        else
        {
            Animator.CrossFade(_runs[dir], 0.2f);
            //Animator.Play(StaticAnimationFields.RUN_FORWARD);
            //Animator.CrossFade()
        }
        lastSpeed = personController.TargetSpeed;
        checkDir = dir;

        //personController.checkDir = dir;


    }

}
