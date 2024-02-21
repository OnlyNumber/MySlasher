using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    public abstract float GetCurrentSpeed();

    public abstract float GetCurrentSprintSpeed();

    public abstract void AddOnChangeDirection(System.Action<int> addAction);

    public abstract void RemoveOnChangeDirection(System.Action<int> removeAction);

}
