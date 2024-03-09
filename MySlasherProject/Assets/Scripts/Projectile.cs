using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    protected MyTriggerAttack MyTriggerAttack;

    [SerializeField]
    protected float Speed;

    [SerializeField]
    protected int Damage;

    protected Quaternion Angle;

    public virtual void Initialize(int damage, Quaternion angle)
    {
        Damage = damage;
        Angle = angle;
    }
}
