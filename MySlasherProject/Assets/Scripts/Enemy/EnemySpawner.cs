using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyFabric _enemyFabric;

    [SerializeField]
    private List<EnemyController> _enemyList = new List<EnemyController>();

    [SerializeField]
    private List<Transform> _spawPoints;

    [SerializeField]
    private Transform _player;

    public void Initialize(Transform player)
    {
        _player = player;

    }

    private void Update()
    {


        foreach (var item in _enemyList)
        {
            item.OnUpdate();
        }

    }

    public void RemoveEnemy(EnemyController enemyController)
    {
        _enemyList.Remove(enemyController);

        if (_enemyList.Count <= 0)
        {
            SpawnWave();
        }


    }

    public void SpawnWave()
    {
        for (int i = 0; i < _spawPoints.Count; i++)
        {
            EnemyController transfer = _enemyFabric.Get((EnemyFabric.EnemyType)Random.Range(0, 3), _spawPoints[i].position,Quaternion.identity);

            //EnemyController transfer = _enemyFabric.Get(EnemyFabric.EnemyType.melee);

            transfer.transform.position = _spawPoints[i].position;
            //transfer.transform.position = _spawPoints[4].position;

            transfer.Initialize(_player, this);
            _enemyList.Add(transfer);
        }
    }


}
