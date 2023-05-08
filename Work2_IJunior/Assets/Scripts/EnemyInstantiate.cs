using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoints;

    private Transform[] _points;

    private void Start()
    {
        InitializePoints();

        StartCoroutine(CreateEnemys());
    }

    private IEnumerator CreateEnemys()
    {
        var waitTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < _points.Length; i++)
        {
            yield return waitTwoSeconds;

            Instantiate(_enemy, _points[i].position, Quaternion.identity); 
        }
    }

    private void InitializePoints()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }
    }
}
