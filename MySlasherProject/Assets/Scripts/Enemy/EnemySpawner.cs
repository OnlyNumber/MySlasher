using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyFabric _enemyFabric;

    [SerializeField]
    private List<EnemyController> _enemyList = new List<EnemyController>();

    private void Update()
    {
        foreach (var item in _enemyList)
        {
            item.OnUpdate();
        }
    }

}
