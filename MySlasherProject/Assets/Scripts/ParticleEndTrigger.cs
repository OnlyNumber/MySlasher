using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEndTrigger : MonoBehaviour
{
    public ParticleSystem ParticleSystemCurrent;

    public System.Action OnParticlesTopped;

    private void Start()
    {
        //ParticleSystemCurrent = GetComponent<ParticleSystem>();

        var m = ParticleSystemCurrent.main;


        Debug.Log("Duration " + m.duration);
        m.stopAction = ParticleSystemStopAction.Callback;
    }

    private void OnParticleSystemStopped()
    {
        OnParticlesTopped?.Invoke();
    }

}
