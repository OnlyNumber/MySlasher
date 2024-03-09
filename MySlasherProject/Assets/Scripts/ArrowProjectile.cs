using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : Projectile
{


    public override void Initialize(int damage, Quaternion angle)
    {
        base.Initialize(damage, angle);

        Debug.Log("Arrow initialize. angle: " + angle);

        transform.rotation = angle;
        MyTriggerAttack.OnTriggerAttack += AttackMethod;

    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * Speed;
    }

    private void AttackMethod(Collider collider)
    {
        HealthHandler healthHandler = collider.GetComponent<HealthHandler>();

        healthHandler.ChangeHealth(-Damage);

        if (collider.TryGetComponent(out IStunAble enemyController))
        {
            enemyController.GoToStunState();
        }

        Destroy(gameObject);
    }


}
