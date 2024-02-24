using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTriggerAttack : MonoBehaviour
{
    public System.Action<Collider> OnTriggerAttack;

    private void OnTriggerEnter(Collider other)
    {
        
        //if(other.gameObject.CompareTag("Enemy"))
        OnTriggerAttack?.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnTriggerAttack?.Invoke(collision.collider);

    }

}
