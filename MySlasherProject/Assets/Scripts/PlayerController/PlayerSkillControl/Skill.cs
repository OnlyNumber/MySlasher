using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skill
{
    public float CooldownTime;

    public float CurrentCooldownTime;

    public float DamageModifier;

    public float ForcePowerPlayer;

    public float ForcePowerToEnemy;

    public float TimeBeforeStopCollider;

    public Sprite IcoSkill;

    public string SkillDescription;


}
