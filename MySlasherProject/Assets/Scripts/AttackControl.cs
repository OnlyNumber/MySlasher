using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class AttackControl : MonoBehaviour
{
    [SerializeField]
    private List<MyTriggerAttack> _collidersList = new List<MyTriggerAttack>();

    [SerializeField]
    private ParticleSystem _particlePrefab;

    [SerializeField]
    private LayerMask mask;

    IAttackAble attackAble;

    public float ForceToEnemy = 10;

    public System.Action OnSetupCollider;

    private ImpactReceiver _myImpactReceiver;

    public float CurrentAttackForce = 20;

    public float CurrentAttackDelayBeforeStop = 0.1f;

    private void Start()
    {
        attackAble = GetComponent<IAttackAble>();

        _myImpactReceiver = GetComponent<ImpactReceiver>();

        foreach (var item in _collidersList)
        {
            item.OnTriggerAttack += Attack;
        }

        if (TryGetComponent(out ThirdPersonController thirdPersonController))
        {
            OnSetupCollider += PushForwardAttack;
        }

    }

    public void PushForwardAttack()
    {
        //Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100000f, mask);

        //Vector3 mousePos = info.point;
        //Vector3 dif = mousePos - transform.position;

        //var lDirection = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), 0, Mathf.Cos(Mathf.Deg2Rad * angle));
        
        float angle = transform.rotation.y;

        if(angle < 0)
        {
            angle = 360 + angle; 
        }

        Vector3 newForward = Quaternion.Euler(0, angle, 0) * transform.forward;
        
        
        //Debug.Log(newForward.normalized);


        _myImpactReceiver.AddImpact(newForward.normalized * CurrentAttackForce);
    }

    public void Attack(Collider collider)
    {

        Instantiate(_particlePrefab, collider.transform.position, Quaternion.identity);

        Vector3 dir = collider.transform.position - transform.position;
        dir.y = 0; // keep the force horizontal
                   // try to get rigidbody of other object
        
        Rigidbody rb = collider.GetComponent<Rigidbody>();

        if (rb)
        { // use AddForce for rigidbodies:
            rb.AddForce(dir.normalized * ForceToEnemy);
        }
        else
        {
            // try to get the enemy's script ImpactReceiver:
            ImpactReceiver script = collider.GetComponent<ImpactReceiver>();
            // if it has such script, add the impact force:
            if (script) script.AddImpact(dir.normalized * ForceToEnemy);
        }


        if (collider.TryGetComponent(out IStunAble enemyController))
        {
            enemyController.GoToStunState();
        }

        if(collider.TryGetComponent(out HealthHandler healthHandler))
        {
            healthHandler.ChangeHealth(-(int)attackAble.GetDamage());
        }
    }

    public void SetupCollider(int index)
    {
        _collidersList[index].gameObject.SetActive(true);


        OnSetupCollider?.Invoke();

        StopAllCoroutines();
        StartCoroutine(StopAttack(index, CurrentAttackDelayBeforeStop));
    }

    IEnumerator StopAttack(int index,float delay)
    {
        yield return new WaitForSeconds(delay);
        _collidersList[index].gameObject.SetActive(false);
    }


    public void StopAddForce()
    {
        attackAble.SetAttackingState(false);
    }
}
