using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class AttackControl : MonoBehaviour
{
    [SerializeField]
    private Transform _startAttackPoint;
    [SerializeField]
    private Transform _endtAttackPoint;

    [SerializeField]
    private List<MyTriggerAttack> _attackEnemyesLit = new List<MyTriggerAttack>();

    [SerializeField]
    private ParticleSystem _particlePrefab;

    public LayerMask mask;

    IAttackAble attackAble;

    private void Start()
    {
        foreach (var item in _attackEnemyesLit)
        {
            item.OnTriggerAttack += Attack;
        }

        attackAble = GetComponent<IAttackAble>();
    }

    public float force = 10;
    public void Attack(Collider collider)
    {
        Instantiate(_particlePrefab, collider.transform.position, Quaternion.identity);

        Vector3 dir = collider.transform.position - transform.position;
        dir.y = 0; // keep the force horizontal
                   // try to get rigidbody of other object
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

        //Physics.Linecast()
    }

    public void SetupCollider(int index)
    {

        _attackEnemyesLit[index].gameObject.SetActive(true);

        ImpactReceiver script = GetComponent<ImpactReceiver>();

        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit info, 100000f, mask);

        Vector3 mousePos = info.point;// Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dif = mousePos - transform.position;
        if (script) script.AddImpact(dif.normalized * 20);
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


    private void Update()
    {


        
        /*if(Physics.Linecast(_startAttackPoint.position, _endtAttackPoint.position, out RaycastHit info))
        {
            if(info.collider.gameObject.CompareTag("Enemy"))
            Debug.Log(info.collider.gameObject.name);
        }*/
        
        //if(info.)

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Detected");
        }

        Debug.Log("Detected");

    }*/

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Detected OnTriggerStay:" + other.gameObject.name);

    }
    


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Detected");
        }
        Debug.Log("Detected OnTriggerEnter:" + other.gameObject.name);

    }*/




}
