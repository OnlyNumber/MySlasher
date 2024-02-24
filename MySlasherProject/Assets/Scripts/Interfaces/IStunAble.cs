using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStunAble
{
    public abstract float GetStunTime();

    public void SetStun(bool state);

    public void GoToStunState();

}
