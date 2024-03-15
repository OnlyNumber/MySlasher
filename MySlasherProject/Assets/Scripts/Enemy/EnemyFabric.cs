using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFabric")]
public class EnemyFabric : ScriptableObject
{
    [SerializeField]
    private EnemyController _meleeEnemy;

    [SerializeField]
    private EnemyController _archerEnemy;
    
    [SerializeField]
    private EnemyController _mageEnemy;


    private EnemyController Get(EnemyController prefab)
    {
        return Instantiate(prefab);
    }

    private EnemyController Get(EnemyController prefab, Vector3 position, Quaternion rotation)
    {
        return Instantiate(prefab, position, rotation);
    }


    public EnemyController Get(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.melee:
                {
                    return Get(_meleeEnemy);
                }
            case EnemyType.archer:
                {
                    return Get(_archerEnemy);
                }
            case EnemyType.mage:
                {
                    return Get(_mageEnemy);
                }
        }

        return Get(_meleeEnemy);

    }

    public EnemyController Get(EnemyType type, Vector3 position, Quaternion rotation)
    {
        switch (type)
        {
            case EnemyType.melee:
                {
                    return Get(_meleeEnemy, position,rotation);
                }
            case EnemyType.archer:
                {
                    return Get(_archerEnemy, position, rotation);
                }
            case EnemyType.mage:
                {
                    return Get(_mageEnemy, position, rotation);
                }
        }

        return Get(_meleeEnemy, position, rotation);

    }


    public enum EnemyType
    {
        melee,
        archer,
        mage
    }

}

