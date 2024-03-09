using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRMB : State
{
    IAttackAble attackAble;

    public AttackRMB(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {

        attackAble = StateManager.GetStateManagerOwner().GetComponent<IAttackAble>();

    }

    public override void OnEnter()
    {
        attackAble.SetAttackingState(true);
        attackAble.SetCheckAttackState(false);
        Animator.CrossFade(StaticAnimationFields.ATTACK_SECOND_SKILL, 0.1f);
    }

    public override void OnExit()
    {
        attackAble.SetCheckAttackState(true);
        attackAble.SetAttackInput(false);
        attackAble.SetAttackingState(false);
    }


    public override void OnUpdate()
    {

    }
}
