using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class SkillControl : MonoBehaviour
{

    [SerializeField]
    private List<Skill> _skils;

    [SerializeField]
    private List<Image> _icons;

    [SerializeField]
    private List<Image> _cooldownIcons;

    public string CurrentAttacName;

    private AttackControl _attackControl;

    private StarterAssetsInputs _input;

    [SerializeField]
    private StateManager _stateManager;

    private void Start()
    {
        _attackControl = GetComponent<AttackControl>();
        _input = GetComponent<StarterAssetsInputs>();
        //_stateManager = GetComponent<StateManager>();
    }

    private void Update()
    {
        for (int i = 0; i < _skils.Count; i++)
        {
            _skils[i].CurrentCooldownTime -= Time.deltaTime;
        }

        for (int i = 0; i < _skils.Count; i++)
        {
            _cooldownIcons[i].fillAmount = _skils[i].CurrentCooldownTime / _skils[i].CooldownTime;
        }


    }

    public void CheckAttack()
    {
        if (_input.attack == true && _skils[0].CurrentCooldownTime <= 0)
        {
            _attackControl.CurrentAttackForce = _skils[0].ForcePowerPlayer;
            _attackControl.CurrentAttackDelayBeforeStop = _skils[0].TimeBeforeStopCollider;
            _attackControl.ForceToEnemy = _skils[0].ForcePowerToEnemy;
            _skils[0].CurrentCooldownTime = _skils[0].CooldownTime;


            _stateManager.ChangeState(StateEnum.attackCombo);
            _input.attack = false;
            _input.jump = false;
        }

        if (_input.attackSecondSkill && _skils[1].CurrentCooldownTime <= 0)
        {
            Debug.Log("SkillControl second skill");
            CurrentAttacName = StaticAnimationFields.ATTACK_SECOND_SKILL;
            _attackControl.CurrentAttackForce = _skils[1].ForcePowerPlayer;
            _attackControl.CurrentAttackDelayBeforeStop = _skils[1].TimeBeforeStopCollider;
            _attackControl.ForceToEnemy = _skils[1].ForcePowerToEnemy;
            _skils[1].CurrentCooldownTime = _skils[1].CooldownTime;


            _stateManager.ChangeState(StateEnum.attack);

            _input.attackSecondSkill = false;
            _input.jump = false;

        }

        if (_input.attackThirdSkill && _skils[2].CurrentCooldownTime <= 0)
        {
            CurrentAttacName = StaticAnimationFields.ATTACK_THIRD_SKILL;

            _attackControl.CurrentAttackForce = _skils[2].ForcePowerPlayer;
            _attackControl.CurrentAttackDelayBeforeStop = _skils[2].TimeBeforeStopCollider;
            _attackControl.ForceToEnemy = _skils[2].ForcePowerToEnemy;
            _skils[2].CurrentCooldownTime = _skils[2].CooldownTime;


            _stateManager.ChangeState(StateEnum.attack);

            _input.attackThirdSkill = false;
            _input.jump = false;

        }

        if (_input.attackFourthSkill && _skils[3].CurrentCooldownTime <= 0)
        {
            CurrentAttacName = StaticAnimationFields.ATTACK_FOURTh_SKILL;
            _attackControl.CurrentAttackForce = _skils[3].ForcePowerPlayer;
            _attackControl.CurrentAttackDelayBeforeStop = _skils[3].TimeBeforeStopCollider;
            _attackControl.ForceToEnemy = _skils[3].ForcePowerToEnemy;
            _skils[3].CurrentCooldownTime = _skils[3].CooldownTime;


            _stateManager.ChangeState(StateEnum.attack);

            _input.attackFourthSkill = false;
            _input.jump = false;
        }
    }

    
}
