using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : State
{
    private IStunAble _stunAble;


    private float _currentTimeStun;

    public Stun(Animator animator, StateManager stateManager) : base(animator, stateManager)
    {
        _stunAble = StateManager.GetStateManagerOwner().GetComponent<IStunAble>();
    }

    public override void OnEnter()
    {
        Debug.Log("StartStun");

        if(Animator.GetCurrentAnimatorStateInfo(0).IsName(StaticAnimationFields.STUN))
        {
            //Animator.Play(StaticAnimationFields.IDLE);

            //Animator.Play(StaticAnimationFields.STUN);

            Animator.Play(StaticAnimationFields.STUN, -1, 0f);


        }

        //Animator.Play(StaticAnimationFields.STUN, -1, 0f);

        Animator.Play(StaticAnimationFields.STUN);
        _stunAble.SetStun(true);
        _currentTimeStun = _stunAble.GetStunTime();
    }

    public override void OnExit()
    {
        _stunAble.SetStun(false);

    }

    public override void OnUpdate()
    {
        if(_currentTimeStun <= 0)
        {
            StateManager.BackToIdle();
        }
        _currentTimeStun -= Time.deltaTime;

    }
}
