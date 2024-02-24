using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> particleSystemList;

    public void ParticleAttack(int particle)
    {
        particleSystemList[particle].Play();
    }
}
