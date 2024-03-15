using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public void SetTime(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
