using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private List<Projectile> _myProjectilesPrefabs;
    
    [SerializeField]
    private Transform _projectileStartPosition;

    IAttackAble attackAble;

    private void Start()
    {
        attackAble = GetComponent<IAttackAble>();
    }

    public void SetupProjectile(int index)
    {
        Projectile transfer = Instantiate(_myProjectilesPrefabs[index], _projectileStartPosition.position, Quaternion.identity);

        //attackAble = 
        //Debug.Log(Quaternion.);
        transfer.Initialize((int)attackAble.GetDamage(), transform.rotation);

    }



}
