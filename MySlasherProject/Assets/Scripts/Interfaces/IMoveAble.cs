using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveAble
{
    //public System.Action<int> OnChangeDirectionIndex { get; set; }

    public abstract float GetCurrentSpeed();

    public abstract float GetCurrentSprintSpeed();

    public abstract void AddOnChangeDirection(System.Action<int> addAction);

    public abstract void RemoveOnChangeDirection(System.Action<int> removeAction);

    public abstract int CurrentDirection();

    public abstract int AmountOfDirections();

}
