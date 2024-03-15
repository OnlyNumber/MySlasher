using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill")]
public class Skill : ScriptableObject
{
    public float CooldownTime;

    public float CurrentCooldownTime;

    public float DamageModifier;

    public float ForcePowerPlayer;

    public float ForcePowerToEnemy;

    public float TimeBeforeStopCollider;

    public Sprite IconSkill;

    public string SkillDescription;


}
