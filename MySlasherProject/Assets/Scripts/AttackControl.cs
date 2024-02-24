using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class AttackControl : MonoBehaviour
{
    [SerializeField]
    private List<MyTriggerAttack> _attackEnemyesLit = new List<MyTriggerAttack>();

    [SerializeField]
    private ParticleSystem _particlePrefab;

    [SerializeField]
    private LayerMask mask;

    [SerializeField, Tooltip("Enter here what layers can hit character")]
    private List<int> _attackLayer;

    IAttackAble attackAble;

    public float force = 10;

    public System.Action OnSetupCollider;

    private ImpactReceiver _myImpactReceiver;

    private void Start()
    {
        attackAble = GetComponent<IAttackAble>();

        _myImpactReceiver = GetComponent<ImpactReceiver>();

        foreach (var item in _attackEnemyesLit)
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
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100000f, mask);

        Vector3 mousePos = info.point;
        Vector3 dif = mousePos - transform.position;
        _myImpactReceiver.AddImpact(dif.normalized * 20);
    }

    public void Attack(Collider collider)
    {

        Instantiate(_particlePrefab, collider.transform.position, Quaternion.identity);

        Vector3 dir = collider.transform.position - transform.position;
        dir.y = 0; // keep the force horizontal
                   // try to get rigidbody of other object
        bool isRightLayer = false;

        foreach (var item in _attackLayer)
        {
            //Debug.Log((collider.gameObject.layer) + "== " + item + collider.gameObject.name);
            if (collider.gameObject.layer == item)
            {
                isRightLayer = true;
            }
        }

        if(!isRightLayer)
        {
            return;
        }

        //Debug.Log("GetHit");
        Rigidbody rb = collider.GetComponent<Rigidbody>();

        if (rb)
        { // use AddForce for rigidbodies:
            rb.AddForce(dir.normalized * force);
        }
        else
        {
            // try to get the enemy's script ImpactReceiver:
            ImpactReceiver script = collider.GetComponent<ImpactReceiver>();
            // if it has such script, add the impact force:
            if (script) script.AddImpact(dir.normalized * force);
        }

        if(collider.TryGetComponent(out HealthHandler healthHandler))
        {
            healthHandler.ChangeHealth(-(int)attackAble.GetDamage());
        }

        if (collider.TryGetComponent(out IStunAble enemyController))
        {
            enemyController.GoToStunState();
        }

    }

    public void SetupCollider(int index)
    {
        _attackEnemyesLit[index].gameObject.SetActive(true);


        OnSetupCollider?.Invoke();

        /*ImpactReceiver script = GetComponent<ImpactReceiver>();

        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100000f, mask);

        Vector3 mousePos = info.point;
        Vector3 dif = mousePos - transform.position;
        if (script) script.AddImpact(dif.normalized * 20);*/

        StopAllCoroutines();
        StartCoroutine(StopAttack(index));
    }

    IEnumerator StopAttack(int index)
    {
        yield return new WaitForSeconds(0.1f);
        _attackEnemyesLit[index].gameObject.SetActive(false);
    }

    public void StopAddForce()
    {
        attackAble.SetAttackingState(false);
    }
}
