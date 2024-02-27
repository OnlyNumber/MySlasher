using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : State
{
    private IMoveAble moveAble;
    private IAttackAble attackAble;
    private List<string> _dodges = new List<string>();

    public Dodge(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        moveAble = StateManager.GetStateManagerOwner().GetComponent<IMoveAble>();
        attackAble = StateManager.GetStateManagerOwner().GetComponent<IAttackAble>();
        _dodges.Add(StaticAnimationFields.DODGE_FORWARD);
        _dodges.Add(StaticAnimationFields.DODGE_RIGHT);
        _dodges.Add(StaticAnimationFields.DODGE_BACK);
        _dodges.Add(StaticAnimationFields.DODGE_LEFT);
    }

    public override void OnEnter()
    {
        Debug.Log("Dodge");
        //attackAble.SetAttackingState(true);
        float direction = moveAble.GetAmountOfDirections()/_dodges.Count;
        //StateManager.GetStateManagerOwner().GetComponent<ImpactReceiver>().AddImpact(StateManager.GetStateManagerOwner().transform.forward * 80);
        Animator.CrossFade(_dodges[(int)(moveAble.GetCurrentDirection()/ direction)], 0.1f);
        //attackAble.SetAttackingState(false);
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
    }

}
