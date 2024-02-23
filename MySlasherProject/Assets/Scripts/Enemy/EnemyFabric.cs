using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFabric")]
public class EnemyFabric : ScriptableObject
{
    [SerializeField]
    private EnemyController _meleeEnemy;

    private EnemyController Get(EnemyController prefab)
    {
        return Instantiate(prefab);
    }

    public EnemyController Get(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.melee:
                {
                    return Get(_meleeEnemy);
                    break;
                }
        }

        return Get(_meleeEnemy);

    }

    public enum EnemyType
    {
        melee
    }

}

