using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackAble
{
    public abstract void SetAttackState(bool state);

    public abstract bool GetAttackState();


}
