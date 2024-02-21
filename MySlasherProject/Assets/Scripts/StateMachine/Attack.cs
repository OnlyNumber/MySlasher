using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Attack : State
{
    private ThirdPersonController _personController;
    private int _currentAttackIndex = 0;
    private List<string> _attacks = new List<string>();

    public Attack(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        _personController = StateManager.GetThirdPersonController();
        _attacks.Add(StaticAnimationFields.ATTACK_1);
        _attacks.Add(StaticAnimationFields.ATTACK_2);
        _attacks.Add(StaticAnimationFields.ATTACK_3);
    }

    public override void OnEnter()
    {
        Animator.CrossFade(_attacks[_currentAttackIndex], 0.1f);
        _personController.IsAttacking = true;
        StateManager.OnStateManagerUpdate -= StateManager.CheckAttack;
        _currentAttackIndex++;
    }

    public override void OnExit()
    {
        _currentAttackIndex = 0;
        StateManager.OnStateManagerUpdate += StateManager.CheckAttack;
        StateManager.Input.attack = false;
    }

    public override void OnUpdate()
    {
        if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !Animator.GetCurrentAnimatorStateInfo(0).IsName(StaticAnimationFields.IDLE))
        {
            StateManager.ChangeState(StateManager.StateEnum.idle);
        }

        if (StateManager.Input.attack == true &&
            Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f &&
            _currentAttackIndex < _attacks.Count &&
            !Animator.IsInTransition(0))
        {
            

            Animator.CrossFade(_attacks[_currentAttackIndex], 0.1f);
            _personController.IsAttacking = true;

            _currentAttackIndex++;

            StateManager.Input.attack = false;
        }
        else if(_currentAttackIndex >= _attacks.Count && Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
        {
            _currentAttackIndex = 0;
            StateManager.Input.attack = false;
        }
    }

    


}