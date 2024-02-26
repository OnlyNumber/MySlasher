using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : State
{
    private IMoveAble moveAble;
    private List<string> _dodges;

    public Dodge(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        moveAble = StateManager.GetStateManagerOwner().GetComponent<IMoveAble>();
        _dodges.Add(StaticAnimationFields.WALK_FORWARD);
        _dodges.Add(StaticAnimationFields.WALK_RIGHT);
        _dodges.Add(StaticAnimationFields.WALK_BACK);
        _dodges.Add(StaticAnimationFields.WALK_LEFT);
    }

    public override void OnEnter()
    {
        

        //Animator.CrossFade(_dodges[])
    }

    public override void OnExit()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        throw new System.NotImplementedException();
    }

}
