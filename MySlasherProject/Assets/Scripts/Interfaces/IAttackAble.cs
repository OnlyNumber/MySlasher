using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackAble
{
    /// <summary>
    /// Set for is attacking object
    /// </summary>
    /// <param name="state"></param>
    public abstract void SetAttackingState(bool state);

    /// <summary>
    /// Get is attacking object
    /// </summary>
    /// <returns></returns>
    public abstract bool GetAttackingState();

    /// <summary>
    /// Set is input to attack
    /// </summary>
    /// <param name="state"></param>
    public abstract void SetAttackInput(bool state);

    /// <summary>
    /// Is input to attack
    /// </summary>
    /// <param name="state"></param>
    public abstract bool GetAttackInput();

    /// <summary>
    /// Set input attack check
    /// </summary>
    /// <param name="state"></param>
    public abstract void SetCheckAttackState(bool state);

    public abstract float GetDamage();


}
