using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePanel : MonoBehaviour
{
    public void SetActivity(bool activate)
    {
        gameObject.SetActive(activate);
    }

    public bool IsShowed()
    {
        return gameObject.activeInHierarchy;
    }


}
