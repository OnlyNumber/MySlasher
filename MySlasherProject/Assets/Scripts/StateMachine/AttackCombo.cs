using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class AttackCombo : State
{
    private ThirdPersonController _personController;
    private int _currentAttackIndex = 0;
    private List<string> _attacks = new List<string>();

    IAttackAble attackAble;

    public AttackCombo(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {

        attackAble = StateManager.GetStateManagerOwner().GetComponent<IAttackAble>();

        _attacks.Add(StaticAnimationFields.ATTACK_1);
        _attacks.Add(StaticAnimationFields.ATTACK_2);
        _attacks.Add(StaticAnimationFields.ATTACK_3);
    }

    public override void OnEnter()
    {
        attackAble.SetAttackingState(true);

        attackAble.SetCheckAttackState(false);
        //StateManager.OnStateManagerUpdate -= StateManager.CheckAttack;
        Animator.Play(_attacks[_currentAttackIndex]);
        _currentAttackIndex++;
    }

    public override void OnExit()
    {
        _currentAttackIndex = 0;
        attackAble.SetCheckAttackState(true);
        attackAble.SetAttackInput(false);

        //StateManager.OnStateManagerUpdate += StateManager.CheckAttack;
        //StateManager.Input.attack = false;
    }

    public override void OnUpdate()
    {
        if (attackAble.GetAttackInput() == true &&
            Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f &&
            _currentAttackIndex < _attacks.Count &&
            !Animator.IsInTransition(0) && 
            !Animator.GetCurrentAnimatorStateInfo(0).IsName(StaticAnimationFields.IDLE))
        {

            attackAble.SetAttackingState(true);
            Animator.Play(_attacks[_currentAttackIndex]);

            _currentAttackIndex++;
            attackAble.SetAttackInput(false);
        }
        else if (_currentAttackIndex >= _attacks.Count && Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            _currentAttackIndex = 0;
            //attackAble.SetAttackInput(false);

        }
            StateManager.GetComponent<StarterAssetsInputs>().jump = false;
    }

    public bool CheckAttack()
    {
        foreach (var item in _attacks)
        {
            if(Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && Animator.GetCurrentAnimatorStateInfo(0).IsName(item))
            {
                return false;
            }
        }
        return true;
    }




}