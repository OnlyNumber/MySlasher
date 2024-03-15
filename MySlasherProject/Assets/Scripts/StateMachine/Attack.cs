using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    private IAttackAble attackAble;


    public Attack(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {

        attackAble = StateManager.GetStateManagerOwner().GetComponent<IAttackAble>();

        //_personController = StateManager.GetThirdPersonController();
    }

    public override void OnEnter()
    {
        Debug.Log("Start attack");

        attackAble.SetAttackingState(true);
        attackAble.SetCheckAttackState(false);

        Animator.Play(attackAble.GetCurrentAttackName());
        //Animator.CrossFade(attackAble.GetCurrentAttackName(), 0.1f);
    }

    public override void OnExit()
    {
        attackAble.SetCheckAttackState(true);
        attackAble.SetAttackInput(false);
        attackAble.SetAttackingState(false);

        OnStateExit?.Invoke();

    }


    public override void OnUpdate()
    {

    }

    
}
